#region Usings
using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;
using HelperSharp;


#endregion

namespace Skahal.Infrastructure.Framework.Text
{
    /// <summary>
    /// Classe utilitária para strings.
    /// </summary>
	public static class StringHelper
    {
        #region Format
        /// <summary>
        /// Formats the specified format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames", MessageId = "0#")]
        public static string Format(string format, params object[] args)
        {
            return String.Format(CultureInfo.CurrentUICulture, format, args);
        }
        #endregion

        #region FormatSingularOrPlural
        /// <summary>
        /// Executa um StringHelper.Format levando em conta o valor de counter,
        /// se counter for maior que 1 então utilizará a string informada em formatPlural, 
        /// caso contrário utilizará a string informada em formatSingular.
        /// </summary>
        /// <param name="counter">O contador para definir se será utilizado a string para singular ou plural.</param>
        /// <param name="formatSingular">A string para singular.</param>
        /// <param name="formatPlural">A string para plural.</param>
        /// <param name="args">Os argumentos para as strings.</param>
        /// <returns>Retorna a string formatada (formatSingular ou formatPlural) com os valores.</returns>
        public static string FormatSingularOrPlural(int counter, string formatSingular, string formatPlural, params object[] args)
        {
            return Format(Math.Abs(counter) > 1 ? formatPlural : formatSingular, args);
        }
        #endregion

        #region Split
        /// <summary>
        /// Splits the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>The string array of split parts.</returns>
        [SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")]
        public static string[] Split(string source, string separator)
        {
            ExceptionHelper.ThrowIfNull(source, "source");
            string[] separators = new string[] {separator};

            return source.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }
        #endregion

        #region ReplaceChar
        /// <summary>
        /// Replaces the char on specified position.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="index">The index.</param>
        /// <param name="replace">The replace.</param>
        /// <returns></returns>
        public static string ReplaceChar(string source, int index, char replace)
        {
            return ReplaceChar(source, index, replace.ToString());
        }

        /// <summary>
        /// Replaces the char on specified position.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="index">The index.</param>
        /// <param name="replace">The replace.</param>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")]
        public static string ReplaceChar(string source, int index, string replace)
        {
            ExceptionHelper.ThrowIfNull(source, "source");            
         //   ExceptionHelper.ThrowArgumentOutOfRangeException("index", index, 0, source.Length - 1);

            
            string firstPart = source.Substring(0, index);
            string secoundPart;

            if (index == int.MaxValue)
            {
                index--;
            }

            if (index + 1 == source.Length)
            {
                secoundPart = string.Empty;
            }
            else
            {
                secoundPart = source.Substring(index + 1, (source.Length - index) - 1);
            }

            return StringHelper.Format("{0}{1}{2}", firstPart, replace, secoundPart);
        }
        #endregion

        #region Remove
        /// <summary>
        /// Remove a string após after
        /// </summary>
        /// <param name="source">A string original.</param>
        /// <param name="after">Após essa string tudo deve ser removido.</param>
        /// <returns>A string sem a string após after.</returns>
        public static string RemoveAfter(string source, string after)
        {
            return ReplaceAfter(source, String.Empty, after);
        }        
		
		/// <summary>
		/// Remove qualquer acento e cedilha da string. 
		/// </summary>
		/// <param name="source">String original.</param>
		/// <returns>String com os acentos e cedilhas removidos.</returns>
        public static string RemoveAccents(this string source)
		{
			//8 bit characters 
			byte[] b = Encoding.GetEncoding(1251).GetBytes(source); 

			// 7 bit characters
			string t = Encoding.ASCII.GetString(b);  
			Regex re = new Regex("[^a-zA-Z0-9]=-_/");
			string c = re.Replace(t, " ");
			return c;
		}

        /// <summary>
        /// Remove todos os caracteres não alfanuméricos.
        /// </summary>
        /// <param name="source">A string a ser avaliada.</param>
        /// <returns>A string sem caracteres não alfanuméricos.</returns>
        public static string RemoveNonAlphanumeric(this string source)
        {            
            return Regex.Replace(source, "[^0-9A-Za-z]*", "");           
        }

        /// <summary>
        /// Remove caracteres não numéricos.
        /// </summary>
        /// <param name="source">A string a ser avaliada.</param>
        /// <returns>A string sem caracteres não númericos.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "NonNumeric")]
        public static string RemoveNonNumeric(this string source)
        {
            return Regex.Replace(source, "[^0-9]*", "");
        }
        #endregion

        #region Replace
        /// <summary>
        /// Executa replace da string entre os delimitadores.
        /// </summary>
        /// <param name="source">String onde será feito o replace.</param>
        /// <param name="replace">String para substituir entre os delimitadores.</param>
        /// <param name="firstDelimiter">Primeiro delimitador.</param>
        /// <param name="secondDelimiter">Segundo delimitador.</param>
        /// <param name="removeStringDelimiters">Define se deve remover os delimitadores.</param>
        /// <returns>String com o replace efetuado.</returns>
        public static string ReplaceBetween(string source, string replace, string firstDelimiter, string secondDelimiter, bool removeStringDelimiters)
        {
            return source.Replace(SubstringBetween(source, firstDelimiter, secondDelimiter, removeStringDelimiters), replace);
        }

        /// <summary>
        /// Executa um replace na string antes de before.
        /// </summary>
        /// <param name="source">String onde será feito o replace.</param>
        /// <param name="replace">String para substituir antes de before.</param>
        /// <param name="before">O replace será feito até before.</param>
        /// <returns>String com o replace efetuado.</returns>
        public static string ReplaceBefore(string source, string replace, string before)
        {
            return source.Replace(SubstringBefore(source, before), replace);
        }

        /// <summary>
        /// Executa um replace na string após de after.
        /// </summary>
        /// <param name="source">String onde será feito o replace.</param>
        /// <param name="replace">String para substituir depois de after.</param>
        /// <param name="after">O replace será feito depois de after.</param>
        /// <returns>String com o replace efetuado.</returns>
        public static string ReplaceAfter(string source, string replace, string after)
        {
            ExceptionHelper.ThrowIfNull(source, "source");

            return source.Replace(SubstringAfter(source, after), replace);
        }
        #endregion

        #region Substrings
        /// <summary>
        /// Retorna o trecho da string anterior a before.
        /// </summary>
        /// <param name="source">A string de onde será retirado o trecho.</param>
        /// <param name="before">O delimitador final da string.</param>
        /// <param name="throwError">Se deve lançar exceção caso não localiza a string definida em before.</param>
        /// <returns>O trecho da string antes de before.</returns>
        [SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Utiliza ExceptionHelper.ThrowIfNull")]
        public static string SubstringBefore(string source, string before, bool throwError)
        {
            ExceptionHelper.ThrowIfNull(source, "source");
            ExceptionHelper.ThrowIfNull(before, "before");

            int indexOf = source.IndexOf(before, StringComparison.Ordinal);
            if (indexOf == -1)
            {
                if (throwError)
                {
					//throw new 
                 //   ExceptionHelper.ThrowArgumentOutOfRangeExceptionFormat("StringHelperResource.SubstringBeforeOutOfRangeMessage", before, source);// TODO
                }
                else
                {
                    indexOf = source.Length;
                }
            }

            return source.Substring(0, indexOf);
        }

        /// <summary>
        /// Retorna o trecho da string anterior a before.
        /// </summary>
        /// <param name="source">A string de onde será retirado o trecho.</param>
        /// <param name="before">O delimitador final da string.</param>
        /// <returns>O trecho da string antes de before.</returns>
        public static string SubstringBefore(string source, string before)
        {
            return SubstringBefore(source, before, true);
        }

        /// <summary>
        /// Retorna o trecho da string entre firstDelimiter e secondDelimiter.
        /// </summary>
        /// <param name="source">A string de onde será retirado o trecho.</param>
        /// <param name="firstDelimiter">O primeiro delimitador do trecho da string.</param>
        /// <param name="secondDelimiter">O segundo delimitador do trecho da string.</param>
        /// <returns>O trecho da string entre os delimitadores.</returns>
        public static string SubstringBetween(string source, string firstDelimiter, string secondDelimiter)
        {
            return SubstringBetween(source, firstDelimiter, secondDelimiter, true);
        }

        /// <summary>
        /// Retorna o trecho da string entre firstDelimiter e secondDelimiter.
        /// </summary>
        /// <param name="source">A string de onde será retirado o trecho.</param>
        /// <param name="firstDelimiter">O primeiro delimitador do trecho da string.</param>
        /// <param name="secondDelimiter">O segundo delimitador do trecho da string.</param>
        /// <param name="removeStringDelimiters">Define se os delimitadores devem permanecer na string retornada.</param>
        /// <returns>O trecho da string entre os delimitadores.</returns>
        [SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Utiliza ExceptionHelper.ThrowIfNull")]
        public static string SubstringBetween(string source, string firstDelimiter, string secondDelimiter, bool removeStringDelimiters)
        {
            ExceptionHelper.ThrowIfNull(source, "source");
            ExceptionHelper.ThrowIfNull(firstDelimiter, "firstDelimiter");
            ExceptionHelper.ThrowIfNull(secondDelimiter, "secondDelimiter");

            int indexOfFirstQuote = source.IndexOf(firstDelimiter, StringComparison.Ordinal);
            if (indexOfFirstQuote == -1)
            {
              //  ExceptionHelper.ThrowArgumentOutOfRangeExceptionFormat("StringHelperResource.SubstringBetweenFirstDelimiterOutOfRangeMessage", firstDelimiter, source); // TODO
            }

            if (removeStringDelimiters)
            {
                indexOfFirstQuote += firstDelimiter.Length;
            }

            int indexOfSecondQuote = -1;

            try
            {
                if (secondDelimiter.Length == 0)
                {
                    indexOfSecondQuote = source.Length - (secondDelimiter.Length > 0 ? 1 : 0);
                }
                else
                {
                    indexOfSecondQuote = source.IndexOf(secondDelimiter, indexOfFirstQuote + (firstDelimiter.Length > 0 ? 1 : 0), StringComparison.Ordinal);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
              //  ExceptionHelper.ThrowArgumentOutOfRangeExceptionFormat("StringHelperResource.SubstringBetweenSecondDelimiterOutOfRangeMessage", secondDelimiter, source); // TODO
            }

            if (!removeStringDelimiters)
            {
                indexOfSecondQuote += secondDelimiter.Length;
            }

            return source.Substring(indexOfFirstQuote, indexOfSecondQuote - indexOfFirstQuote);
        }

        /// <summary>
        /// Retorna o trecho da string depois de after.
        /// </summary>
        /// <param name="source">A string de onde será retirado o trecho.</param>
        /// <param name="after">O delimitador inicial da string.</param>
        /// <returns>O trecho da string antes de before.</returns>
        [SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Utiliza ExceptionHelper.ThrowIfNull")]
        public static string SubstringAfter(string source, string after)
        {
            ExceptionHelper.ThrowIfNull(source, "source");
            ExceptionHelper.ThrowIfNull(after, "after");

            int indexOf = source.IndexOf(after, StringComparison.Ordinal);
            if (indexOf == -1)
            {
               // TODO: ExceptionHelper.ThrowArgumentOutOfRangeExceptionFormat("StringHelperResource.SubstringAfterOutOfRangeMessage", after, source); // TODO
            }

            return source.Substring(indexOf + after.Length);
        }
        #endregion               

        #region Joins
        /// <summary>
        /// Faz a união dos itens de uma coleção numa string.
        /// Utiliza "," como separador dos itens.
        /// </summary>
        /// <param name="collection">Os itens a serem unidos numa string.</param>
        /// <returns>A string com os itens unidos.</returns>
        public static string Join(ICollection collection)
        {
            return Join(collection, ",", ",");
        }

		/// <summary>
		/// Joins the words.
		/// </summary>
		/// <returns>The words.</returns>
		/// <param name="collection">Collection.</param>
		public static string JoinWords(ICollection collection)
        {
            return Join(collection, ", ", " and ");
        }

        /// <summary>
        /// Faz a união dos itens de uma coleção numa string.
        /// Utiliza "," como separador dos itens.
        /// </summary>
        /// <param name="collection">Os itens a serem unidos numa string.</param>
        /// <param name="separator">Separador utilizado entre os itens.</param>
        /// <returns>A string com os itens unidos.</returns>
        public static string Join(ICollection collection, string separator)
        {
            return Join(collection, separator, separator);
        }

        /// <summary>
        /// Faz a união dos itens de uma coleção numa string.
        /// Utiliza "," como separador dos itens.
        /// </summary>
        /// <param name="collection">Os itens a serem unidos numa string.</param>
        /// <param name="separator">Separador utilizado entre os itens.</param>
        /// <param name="lastSeparator">Separador entre o penúltimo e o último item.</param>
        /// <returns>A string com os itens unidos.</returns>
        public static string Join(ICollection collection, string separator, string lastSeparator)
        {
            if (collection == null)
            {
                return null;
            }

            StringBuilder sb = new StringBuilder();
            bool isFirst = true;
            int i = 0;

            foreach (object item in collection)
            {
				var itemText = item.ToString();
				
                if (isFirst)
                {
                    sb.Append(itemText);
                    isFirst = false;
                }
                else
                {
                    if (i == collection.Count - 1)
                    {
                        sb.AppendFormat("{0}{1}", lastSeparator, itemText);
                    }
                    else
                    {
                        sb.AppendFormat("{0}{1}", separator, itemText);
                    }
                }
                i++;
            }

            return sb.ToString();
        }
		
        #endregion        
		
		#region Compare
		/// <summary>
        /// Verifica se a string possui caracteres diferentes ou toda a string possui o mesmo caracter.
        /// </summary>
        /// <remarks>
        /// Por exemplo, se a string for "aaaaaa" retornará true, mas se a string for "aaabaaa" retornará false.
        /// </remarks>
        /// <param name="source">A string a ser avaliada.</param>
        /// <returns>True se possui caracteres diferentes, false no contrário.</returns>
        [SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Utiliza ExceptionHelper.ThrowIfNull")]
        public static bool HasDifferentChars(this string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            
            if(source.Length > 1)
            {
                string regex = String.Format("{0}{{{1}}}", Regex.Escape(source[0].ToString()), source.Length);

                return !Regex.IsMatch(source, regex);
            }
            return false;
        }
		#endregion
    
		#region Similarity
		/// <summary>
		/// Gets the similarity between two strings.
		/// <remarks>
		/// Identical strings have 1f similarity.
		/// </remarks>
		/// </summary>
		/// <returns>
		/// The similarity.
		/// </returns>
		/// <param name='string1'>
		/// String1.
		/// </param>
		/// <param name='string2'>
		/// String2.
		/// </param>
		public static float GetSimilarity(string string1, string string2) 
		{ 
		    float dis=ComputeDistance(string1, string2);
		    float maxLen=string1.Length;
		    if (maxLen < string2.Length)
		    maxLen = string2.Length;
		    if (maxLen == 0.0F)
		    return 1.0F;
		    else
		    return 1.0F - dis/maxLen; 
		}
		
		#region Utilities
		private static int ComputeDistance (string s, string t)
		{
		    int n=s.Length;
		    int m=t.Length;
		    int[,] distance=new int[n + 1, m + 1]; // matrix
		
		    int cost=0;
		    if(n == 0) return m;
		    if(m == 0) return n;
		    //init1
		
		    for(int i=0; i <= n; distance[i, 0]=i++);
		    for(int j=0; j <= m; distance[0, j]=j++);
		    //find min distance
		
		    for(int i=1; i <= n; i++)
		    {
		        for(int j=1; j <= m;j++)
		        {
		            cost=(t.Substring(j - 1, 1) == 
		                s.Substring(i - 1, 1) ? 0 : 1);
		            distance[i,j]=Min3(distance[i - 1, j] + 1,
		            distance[i, j - 1] + 1,
		            distance[i - 1, j - 1] + cost);
		        }
		    }
		    return distance[n, m];
		}
		
		private static int Min3(int a, int b, int c)
		{
			return System.Math.Min(System.Math.Min(a, b), c);			
		}
		#endregion
		
		#endregion
	}
}