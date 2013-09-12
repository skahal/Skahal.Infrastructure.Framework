#region Usings
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using Skahal.Infrastructure.Framework.Logging;
#endregion

namespace Skahal.Infrastructure.Framework.Text
{
    /// <summary> 
    /// Permite que sejam criados textos com chaves que serão posteriormente substituídas por valores de objetos e suas propriedades.
    /// <remarks>
    /// Faz a substituição de chaves pelos valores correspondentes dos objetos ou das propriedades desses objetos.
    /// Toda a substituição é feita através de reflection.
    /// Por exemplo, se adicionarmos um objeto bindable do tipo AdvancedMembershipUser, marcando-o com o nome "User", desta forma:
    /// <code>
    /// DynamicTextBuilder textBuilder = new DynamicTextBuilder();
    /// textBuilder.AddBindable("User", user); 
    /// </code>
    /// Poderemos então utilizar as propriedades da instancia de AdvancedMembershipUser para preencher o texto:
    /// <code>
    /// textBuilder.Append("Nome completo: {User.FullName}\nE-mail: {User.Email}");
    /// </code>
    /// Ao chamarmos o método ToString do DynamicTextBuilder receberemos o seguinte resultado como retorno:
    /// Nome completo: Fulano da Beltrano\nE-mail: fulano@ciclano.com.br     
    /// </remarks>
    /// </summary>
    public class DynamicTextBuilder
    {
        #region Constantes
        /// <summary>
        /// Expressão regular para localizar as chaves de binding.
        /// </summary>
        private static readonly Regex s_getBindableKeysRegex = new Regex(@"({*{[a-zA-Z0-9\._#\(\)\s]+}}*)", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);
        #endregion

        #region Campos
        /// <summary>
        /// Armazena os objetos de binding.
        /// </summary>
        private Dictionary<string, object> m_bindables = new Dictionary<string, object>();

        /// <summary>
        /// StringBuilder utilizado internamente para armazenar os textos adicionados.
        /// </summary>
        private StringBuilder m_text = new StringBuilder();

        /// <summary>
        /// Cache para os valores das chaves.
        /// </summary>
        private Dictionary<string, object> m_bindableKeyValuesCache = new Dictionary<string, object>();
		
		private Stack<KeyValuePair<string, bool>> m_ifStack = new Stack<KeyValuePair<string, bool>>();
        #endregion

        #region Métodos

        #region AddBindableObject
        /// <summary>
        /// Adiciona um objeto de binding.
        /// <remarks>
        /// Se adicionarmos um objeto desta forma:
        /// <code>
        /// textBuilder.AddBindable("User", usuario);
        /// </code>
        /// Poderemos utilizá-lo dentro do texto desta forma:
        /// "Nome do usuário: {User.FullName}, e-mail: {User.Email}.
        /// </remarks>
        /// </summary>
        /// <param name="key">A chave que será utilizada para representar os objetos nas chaves de binding.</param>
        /// <param name="bindable">O objeto de binding.</param>
        public void AddBindable(string key, object bindable)
        {
			if(m_bindables.ContainsKey(key))
			{
				m_bindables[key] = bindable;
				m_bindableKeyValuesCache.Clear();
			}
			else
			{
            	m_bindables.Add(key, bindable);
			}
        }
        #endregion

        #region Append
        /// <summary>
        /// Adiciona o texto.
        /// </summary>
        /// <param name="text">O texto a ser adicionado.</param>
        /// <returns>A instância de DynamicTextBuilder.</returns>
        public DynamicTextBuilder Append(string text)
        {
			m_text.Append (text);
            return this;
        }

        /// <summary>
        /// Adiciona uma linha.
        /// </summary>
        /// <returns>A instância de DynamicTextBuilder.</returns>
        public DynamicTextBuilder AppendLine()
        {
            m_text.AppendLine();
            return this;
        }
        #endregion

        #region Clear
        /// <summary>
        /// Remove todo o texto anteriormente adicionado e opcionalmente os objetos bindable.
        /// </summary>
        /// <param name="clearBindable">Se deve remover os objetos bindable.</param>
        public void Clear(bool clearBindable)
        {
            m_text.Remove(0, m_text.Length);

            if (clearBindable)
            {
                m_bindables.Clear();
            }
        }

        /// <summary>
        /// Remove todo o texto anteriormente adicionado.
        /// </summary>
        public void Clear()
        {
            Clear(false);
        }
        #endregion

        #region GetBindableKeysInText
        /// <summary>
        /// Obtém as chaves de binding existentes no texto.
        /// </summary>
        /// <param name="text">O texto a ser avaliado.</param>
        /// <returns>As BindableTextKey localizadas.</returns>
        private static BindableTextKey[] GetBindableKeysInText(string text)
        {
            List<BindableTextKey> bindableKeys = new List<BindableTextKey>();

            MatchCollection matches = s_getBindableKeysRegex.Matches(text);
            int length = matches.Count;

            for (int i = 0; i < length; i++)
            {
                Match m = matches[i];

                if (!BindableTextKey.HasEscape(m.Value)) // Se não estiver com o caracter de escape.
                {
                    bindableKeys.Add(new BindableTextKey(m.Value));
                }
            }

            return bindableKeys.ToArray();
        }
        #endregion

        #region Obtér objetos e propriedades
        /// <summary>
        /// Obtém um objeto bindable pela chave de binding.
        /// </summary>
        /// <param name="key">A BindableTextKey.</param>
        /// <returns>O objeto bindable localizado.</returns>
        private object GetBindable(BindableTextKey key)
        {
            if (m_bindables.ContainsKey(key.ObjectName))
            {
                return m_bindables[key.ObjectName];
            }
            else
            {
                // O objeto não foi localizado
                throw new InvalidOperationException(String.Format("Object '{0}' not found", key.ObjectName));
            }
        }

        /// <summary>
        /// Obtém o valor para uma BindableTextKey.
        /// </summary>
        /// <param name="key">A BindableTextKey.</param>
        /// <returns>O valor da BindableTextKey.</returns>
        private object GetBindableKeyValue(BindableTextKey key)
        {
            // Verifica se ainda não existe no cache.
            if (!m_bindableKeyValuesCache.ContainsKey(key.Name))
            {
                // Obtém o objeto bindable.
                object bindableObject = GetBindable(key);
                object value = null;

                // Se for um bind sem propriedade. Ex.: {User}.
                if (String.IsNullOrEmpty(key.PropertyName))
                {
                    value = bindableObject; // Utiliza o próprio objeto como valor.
                }
                else // Se for um bind com propriedade. Ex.: {User.FullName}.
                {
                    try
                    {
                        // Obtém o valor da propriedade.
                        value = GetPropertyValue(bindableObject, key.PropertyName);
                    }
                    catch (InvalidOperationException ex)
                    {
                        // A propriedade não foi localizada no objeto.
                   		throw new InvalidOperationException(
						                                    String.Format("The property '{0}' was not found on object '{1}'.", key.PropertyName, key.ObjectName),
						                                    ex);
                    }
                }

                // Armazena no cache.
                m_bindableKeyValuesCache[key.Name] = value;
            }

            return m_bindableKeyValuesCache[key.Name];
        }
        #endregion

        #region ToString
        /// <summary>
        /// Monta a representação dos textos adicionados substituindo as chaves de binding pelos valores existentes nos objetos bindable adicionados.
        /// </summary>
        /// <returns>O texto substituído.</returns>
        public override string ToString()
        {
            // Obtém o texto com as BindableKeys.
            string text = m_text.ToString();

            // Obtém as BindableKeys existentes no texto.
            BindableTextKey[] bindableKeys = GetBindableKeysInText(text);

            // Substitui as BindableKeys.
            int length = bindableKeys.Length;

            for (int i = 0; i < length; i++)
            {
                BindableTextKey key = bindableKeys[i];
				
				if(ProcessConditionalKeys(key))
				{
					continue;
				}
				
				var value = GetBindableKeyValue(key);
                m_text.Replace(key.NameWithPrefixAndSuffix, value == null ? String.Empty : String.Format("{0:" + key.Format + "}", value));
            }

            // Retorna o texto com as chaves substituídas.
            return m_text.ToString();
        }
		
		private bool ProcessConditionalKeys (BindableTextKey key)
		{
			// if and endif
			if(key.Name.Equals("#endif", StringComparison.OrdinalIgnoreCase))
			{
				var topInStack = m_ifStack.Pop();
				
				if(topInStack.Value)
				{
					m_text.Replace(key.NameWithPrefixAndSuffix, "");
				}
				else
				{
					var newText = StringHelper.ReplaceBetween(m_text.ToString(), "", topInStack.Key, key.NameWithPrefixAndSuffix, false);
					m_text.Remove(0, m_text.Length);
					m_text.Append(newText);
				}
				
				
				return true;
			}
			else if(m_ifStack.Count > 0 && !m_ifStack.Peek ().Value)
			{
				return true;
			}
			else if(key.Name.StartsWith("#if "))
			{
				var ifValue = (bool)GetBindableKeyValue(key);
				
				if(ifValue)
				{
					m_text.Replace(key.NameWithPrefixAndSuffix, "");
				}
				
				m_ifStack.Push(new KeyValuePair<string, bool>(key.NameWithPrefixAndSuffix, ifValue));
				return !ifValue;
			}
			
			return false;
		}
        #endregion
		
		#region ToObject
		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <returns>The value.</returns>
		/// <param name="bindableKey">Bindable key.</param>
		public object GetValue(string bindableKey)
		{
            string text = bindableKey;
            var bindableKeys = GetBindableKeysInText(text);
			
			if(bindableKeys.Length > 0)
			{
				return GetBindableKeyValue(bindableKeys[0]);
			}
			else
			{
				return null;
			}
		}
		#endregion

        #region Format
        /// <summary>
        /// Monta a representação do texto substituindo as chaves de binding pelos valores existentes no objeto bindable informado.
        /// </summary>
        /// <param name="text">O texto a ser formatado.</param>
        /// <param name="bindableKey">A chave utilizada para o objjeto bindable.</param>
        /// <param name="bindable">O objeto que será utilizado na substituições.</param>
        /// <returns>O texto formatado.</returns>
        public static string Format(string text, string bindableKey, object bindable)
        {
            DynamicTextBuilder builder = new DynamicTextBuilder();

            builder.AddBindable(bindableKey, bindable);
            builder.Append(text);

            return builder.ToString();
        }

        /// <summary>
        /// Chama o método Format levando em conta se utiliza o texto no singular, counter &lt;= 1, ou o texto no plural.
        /// </summary>
        /// <param name="counter">O contador que definirá se será utilizado o texto no singular ou plural.</param>
        /// <param name="singularText">O texto no singular.</param>
        /// <param name="pluralText">O texto no plural.</param>
        /// <param name="bindableKey">A chave utilizada para o objjeto bindable.</param>
        /// <param name="bindable">O objeto que será utilizado na substituições.</param>
        /// <returns>O texto formatado.</returns>
        public static string FormatSingularOrPlural(int counter, string singularText, string pluralText, string bindableKey, object bindable)
        {
            return Format(Math.Abs(counter) > 1 ? pluralText : singularText, bindableKey, bindable);
        }
        #endregion

        #region Reflection

        /// <summary>
        /// Obtém a propriedade no tipo informado.
        /// </summary>
        /// <param name="type">O tipo onde será localizada a propriedade.</param>
        /// <param name="propertyName">O nome da propriedade</param>
        /// <returns>A PropertyInfo localizada.</returns>
        private static PropertyInfo GetProperty(Type type, string propertyName)
        {
            PropertyInfo property = type.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (property == null)
            {
            	throw new InvalidOperationException(String.Format("Property '{0}' not found on type '{1}'.", propertyName, type));
            }

            return property;
        }

        /// <summary>
        /// Obtém o valor de uma propriedade.
        /// </summary>
        /// <param name="instance">O objeto dono da propriedade.</param>
        /// <param name="propertyName">O nome da propriedade.</param>
        /// <returns>O valor da propriedade.</returns>
        private static object GetPropertyValue(object instance, string propertyName)
        {
			if(instance == null)
			{
				throw new ArgumentNullException("instance");
			}
          
            return GetProperty(instance.GetType(), propertyName).GetValue(instance, new object[0]);
        }

        #endregion
        #endregion
    }
}