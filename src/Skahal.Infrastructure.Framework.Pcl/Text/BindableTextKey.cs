#region Usings
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace Skahal.Infrastructure.Framework.Text
{
    /// <summary>
    /// Representa uma chave de binding dentro de um texto da DynamicTextBuilder.
    /// </summary>
    internal class BindableTextKey
    {
        #region Constantes
        /// <summary>
        /// Prefixo de marcação de uma chave de binding.
        /// </summary>
        public const string BindableKeyPrefix = "{";

        /// <summary>
        /// Sufixo de marcação de uma chave de binding.
        /// </summary>
        public const string BindableKeySuffix = "}";

        /// <summary>
        /// Escape para o prefixo de marcação de uma chave de binding.
        /// </summary>
        public const string BindableKeyPrefixEscape = "{{";

        /// <summary>
        /// Escape para o sufixo de marcação de uma chave de binding.
        /// </summary>
        public const string BindableKeySuffixEscape = "}}";
        #endregion

        #region Campos
        /// <summary>
        /// Armazena o nome da chave.
        /// <example>
        /// User.UserName.
        /// </example>
        /// </summary>
        private string m_name;

        /// <summary>
        /// Armazena o nome da chave com prefixo e sufixo.
        /// <example>
        /// {User.UserName}.
        /// </example>
        /// </summary>
        private string m_nameWithPrefixAndSuffix;

        /// <summary>
        /// O nome do objeto.
        /// <example>
        /// User.
        /// </example>
        /// </summary>
        private string m_objectName;

        /// <summary>
        /// O nome da propriedade (se existir).
        /// <example>
        /// UserName.
        /// </example>
        /// </summary>
        private string m_propertyName;
        #endregion

        #region Construtores
        /// <summary>
        /// Inicializa uma nova instância de <see cref="BindableTextKey"/>.
        /// </summary>
        /// <param name="nameWithPrefixAndSuffix">O nome da chave com prefixo e sufixo.</param>
        public BindableTextKey(string nameWithPrefixAndSuffix)
        {
            // Obtém apenas o nome da chave, sem o prefixo e sufixo.
            m_name = nameWithPrefixAndSuffix.Substring(1, nameWithPrefixAndSuffix.Length - 2); 
            m_nameWithPrefixAndSuffix = nameWithPrefixAndSuffix;
            
			var formatParts = m_name.Split(':');
			
			if(formatParts.Length > 1)
			{
				Format = formatParts[1];
			}
			
            // Obtém as partes do nome.
            string[] parts = formatParts[0].Split('.');

            // O nome do objeto.
            m_objectName = parts[0];
            
            // O nome da propriedade (se existir)
            if (parts.Length > 1)
            {
                m_propertyName = parts[1];
            }
        }
        #endregion

        #region Propriedades
        /// <summary>
        /// Obtém o nome.
        /// </summary>
        public string Name
        {
            get
            {
                return m_name;
            }
        }

        /// <summary>
        /// Obtém o nome com prefixo e sufixo.
        /// </summary>
        public string NameWithPrefixAndSuffix
        {
            get
            {
                return m_nameWithPrefixAndSuffix;
            }
        }

        /// <summary>
        /// Obtém o nome do objeto na chave.
        /// </summary>
        public string ObjectName
        {
            get
            {
                return m_objectName;
            }
        }

        /// <summary>
        /// Obtém o nome da propriedade na chave.
        /// </summary>
        public string PropertyName
        {
            get
            {
                return m_propertyName;
            }
        }
		
		public string Format
		{
			get;
			private set;
		}
        #endregion

        #region Métodos
        /// <summary>
        /// Verifica se o texto possui caracteres de escape para as chaves.
        /// </summary>
        /// <param name="text">O texto a ser verificado.</param>
        /// <returns>Se possui caracter de escape para prefixo ou suffixo.</returns>
        public static bool HasEscape(string text)
        {
			if(text == null)
			{
				throw new ArgumentException("text");
			}
          
            return text.StartsWith(BindableKeyPrefixEscape, StringComparison.OrdinalIgnoreCase) || text.EndsWith(BindableKeySuffixEscape, StringComparison.OrdinalIgnoreCase);
        }
        #endregion
    }
}