#region Usings
using System;
using System.Globalization;
using System.Linq;
using Skahal.Infrastructure.Framework.PCL.People;
using Skahal.Infrastructure.Framework.PCL.Logging;
using Skahal.Infrastructure.Framework.PCL.Repositories;
#endregion

namespace Skahal.Infrastructure.Framework.PCL.Globalization
{
	/// <summary>
	/// Globalization service.
	/// </summary>
	public static class GlobalizationService
	{
		#region Events
		/// <summary>
		/// Occurs when culture changed.
		/// </summary>
		public static event EventHandler CultureChanged;
		#endregion

		#region Constants
		private const string CultureNamePreferenceKey = "SHGlobalizationCultureName";
		#endregion
		
		#region Fields
		/// <summary>
		/// Brazilian Portugues culture information.
		/// </summary>
		public static readonly CultureInfo PtBrCultureInfo = new CultureInfo("pt-BR");

		/// <summary>
		/// United States English culture information.
		/// </summary>
		public static readonly CultureInfo EnUsCultureInfo = new CultureInfo("en-US");

		private static CultureInfo s_currentCulture = EnUsCultureInfo;

		private static IGlobalizationLabelRepository s_labelRepository;
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets the current culture.
		/// </summary>
		/// <value>The current culture.</value>
		public static CultureInfo CurrentCulture {
			get {
				if (s_currentCulture == null) {
					s_currentCulture = new CultureInfo(SelectedCultureName);
				}

				return s_currentCulture;
			}
			
			private set {
				if (!s_currentCulture.Name.Equals (value.Name))
				{
					SelectedCultureName = value.Name;
					s_currentCulture = value;
					s_labelRepository.LoadCultureLabels (value.Name);
					
					if (CultureChanged != null)
					{
						CultureChanged (typeof(GlobalizationService), EventArgs.Empty);
					}
				}
			}
		}

		private static string SelectedCultureName 
		{
			get 
			{
				var user = UserService.GetCurrentUser();

				if(user.HasPreference(CultureNamePreferenceKey))
				{
					return user.GetPreference(CultureNamePreferenceKey).Value.ToString();
				}

				return "en-US";
			}
			
			set 
			{ 
				var user = UserService.GetCurrentUser();
				user.SetPreference(CultureNamePreferenceKey, value);
				UserService.SaveCurrentUser(user);
			}
		}
		#endregion
		
		#region Public methods
		/// <summary>
		/// Initialize the service.
		/// </summary>
		/// <param name="labelRepository">Label repository.</param>
		public static void Initialize(IGlobalizationLabelRepository labelRepository)
		{
			s_labelRepository = labelRepository;
			s_labelRepository.LoadCultureLabels (SelectedCultureName);
		}

		/// <summary>
		/// Changes the culture.
		/// </summary>
		/// <param name="cultureName">Culture name.</param>
		public static void ChangeCulture (string cultureName)
		{
			CultureInfo toCulture;
			
			switch (cultureName)
			{
			case "en-US":
				toCulture = EnUsCultureInfo;
				break;
					
			case "pt-BR":
				toCulture = PtBrCultureInfo;
				break;
					
			default:
				toCulture = new CultureInfo (cultureName);
				break;
			}
			
			ChangeCulture (toCulture);
		}

		/// <summary>
		/// Changes the culture.
		/// </summary>
		/// <param name="toCulture">To culture.</param>
		public static void ChangeCulture (CultureInfo toCulture)
		{
			CurrentCulture = toCulture;
		}

		/// <summary>
		/// Translate the specified english text to current culture.
		/// </summary>
		/// <param name="englishText">English text.</param>
		public static string Translate(string englishText)
		{
			if (String.IsNullOrEmpty (englishText)) {
				throw new ArgumentNullException ("englishText"); 
			}

			var translatedLabel = s_labelRepository
				.FindAll (
					f =>   f.EnglishText.Equals(englishText, StringComparison.OrdinalIgnoreCase)
				 		&& f.CultureName == s_currentCulture.Name)
				.FirstOrDefault ();

			if(translatedLabel == null)
			{
				LogService.Warning ("GlobalizationService.Translate: was not possible to translate the text '{0}' to '{1}'.", englishText, s_currentCulture.Name);
				return englishText;
			}

			return translatedLabel.CultureText;
		}
		#endregion
	}
}