using System;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace PuzzlerService
{
    /// <summary>
    /// Summary description for DictionaryService.
    /// </summary>
    public class DictionaryService
    {
        private const string EXCEPTION_POLICY = "Service Policy";

        public static Boolean CheckSpelling(string wordToCheck)
        {
            try
            {
                Dictionary.CheckSpelling(wordToCheck);
                return true;
            }
            catch (Exception e)
            {
                if (ExceptionPolicy.HandleException(e, EXCEPTION_POLICY))
                {
                    throw;
                }

                return false;
            }
        }
        public static void AddWord(string wordToAdd)
        {
            try
            {
                Dictionary.AddWord(wordToAdd);
            }
            catch (Exception e)
            {
                if (ExceptionPolicy.HandleException(e, EXCEPTION_POLICY))
                {
                    throw;
                }
            }
        }

        public static string GetDictionaryInfo()
        {
            try
            {
                return Dictionary.GetDictionaryInfo();
            }
            catch (Exception e)
            {
                if (ExceptionPolicy.HandleException(e, EXCEPTION_POLICY))
                {
                    throw;
                }

                return string.Empty;
            }
        }
    }
}
