//  Author: Diego Giacomelli <giacomelli@gmail.com>
//  Copyright (c) 2011 Skahal Studios
using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace Skahal.Infrastructure.Framework.PCL.IO
{
	/// <summary>
	/// Ofx writer.
	/// </summary>
	public class OfxWriter
	{
		#region Fields
		private StringWriter m_writer;
		#endregion
		
		#region Public methods
		/// <summary>
		/// Write the specified filename and transactions.
		/// </summary>
		/// <param name="filename">Filename.</param>
		/// <param name="transactions">Transactions.</param>
		public void Write(string filename, IOfxTransaction[] transactions)
		{
			Write(filename, String.Empty, transactions);
		}

		/// <summary>
		/// Write the specified filename, accountId and transactions.
		/// </summary>
		/// <param name="filename">Filename.</param>
		/// <param name="accountId">Account identifier.</param>
		/// <param name="transactions">Transactions.</param>
		public void Write(string filename, string accountId, IOfxTransaction[] transactions)
		{
			var orderedTransactions = transactions.OrderBy(t => t.Date);
			
			using(m_writer = new StringWriter())
			{
				WriteHeader();
				
				var doc = CreateDefaultOfxXml(accountId);
				
				if(orderedTransactions.Count() > 0)
				{
					var transactionsNode = doc.SelectSingleNode("OFX/BANKMSGSRSV1/STMTTRNRS/STMTRS/BANKTRANLIST");
					
					// Adds the date.
					var dtStart = doc.CreateElement("DTSTART");
					dtStart.InnerText = FormatDate(orderedTransactions.First().Date);
					transactionsNode.AppendChild(dtStart);
					
					var dtEnd = doc.CreateElement("DTEND");
					dtEnd.InnerText = FormatDate(orderedTransactions.Last().Date);
					transactionsNode.AppendChild(dtEnd);
					
					foreach(var t in orderedTransactions)
					{
						var stmtTrn = doc.CreateElement("STMTTRN");
						
						var dtPosted = doc.CreateElement("DTPOSTED");
						dtPosted.InnerText = FormatDate(t.Date);
						stmtTrn.AppendChild(dtPosted);
						
						var trnAmt = doc.CreateElement("TRNAMT");
						trnAmt.InnerText = t.Value.ToString(CultureInfo.InvariantCulture);
						stmtTrn.AppendChild(trnAmt);
						
						var memo = doc.CreateElement("MEMO");
						memo.InnerText = t.Description;
						stmtTrn.AppendChild(memo);
						
						transactionsNode.AppendChild(stmtTrn);
					}
				}
		
				doc.Save(m_writer);
				
				File.WriteAllText(filename, 
				                  m_writer.ToString().Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", ""),
				                  Encoding.UTF8);
			}
		}
		#endregion
		
		#region Private methods
		
		private void WriteHeader()
		{
			#region Header text
			m_writer.Write(@"OFXHEADER:100
DATA:OFXSGML
VERSION:102
SECURITY:NONE
ENCODING:USASCII
CHARSET:1252
COMPRESSION:NONE
OLDFILEUID:NONE
NEWFILEUID:NONE
");
			#endregion
		}
		
		private XmlDocument CreateDefaultOfxXml(string accountId)
		{
			var doc = new XmlDocument();
			
			#region LoadXml
			doc.LoadXml(String.Format (CultureInfo.InvariantCulture, @"<OFX>
   <BANKMSGSRSV1>
      <STMTTRNRS>
         <TRNUID>1</TRNUID>
         <STATUS>
            <CODE>0</CODE>
            <SEVERITY>INFO</SEVERITY>
         </STATUS>
         <STMTRS>
            <CURDEF>BRL</CURDEF>
            <BANKACCTFROM>
               <BANKID></BANKID>
               <BRANCHID></BRANCHID>
               <ACCTID>{0}</ACCTID>
               <ACCTTYPE>CHECKING</ACCTTYPE>
            </BANKACCTFROM>
            <BANKTRANLIST>
            </BANKTRANLIST>
			<LEDGERBAL>
               <BALAMT></BALAMT>
               <DTASOF></DTASOF>
         	</LEDGERBAL>
         </STMTRS>
	  </STMTTRNRS>
   </BANKMSGSRSV1>
</OFX>", accountId));
			#endregion
			
			return doc;
		}
		
		private string FormatDate(DateTime date)
		{
			return date.ToUniversalTime().ToString("yyyyMMddHHmmss") + "[-3:BRT]";
		}
		#endregion
	}
}

