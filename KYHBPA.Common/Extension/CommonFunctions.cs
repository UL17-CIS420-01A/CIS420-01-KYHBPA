namespace KYHBPA.Common
{

    /// <summary>
    /// Summary description for CommonFunctions
    /// </summary>
    public static class CommonFunctions
    {
        public static string Right(this string inString, int inLong)
        {
            string result = string.Empty;
            int strLength = inString.Length;
            result=inString.Substring(strLength-inLong, inLong);
            return result;
        }

        ///<summary> 
        /// formats a name into proper case 
        ///</summary> 
        ///<param name="name">
        ///</param> 
        ///<returns>
        ///</returns> 
        public static string ProperCase(this string inputName)
        {
            int x = 0;
            string name = string.Empty;
            if((inputName=inputName.Trim().ToLower()).Length!=0)
            {
                do
                {
                    if(x==0)
                    {
                        name=inputName.Substring(x, 1).ToUpper();
                    }
                    else if(inputName.Substring(x-1, 1)==" "||inputName.Substring(x-1, 1)=="'"||
                             inputName.Substring(x-1, 1)=="-")
                    {
                        name+=inputName.Substring(x, 1).ToUpper();
                    }
                    else
                    {
                        name+=inputName.Substring(x, 1);
                    }
                    x++;
                } while(x<inputName.Length);
                if(name.Substring(name.Length-3).ToLower()==" ii")
                {
                    name=name.Substring(0, name.Length-3)+name.Substring(name.Length-3, 3).ToUpper();
                }
                else if(name.Substring(name.Length-4).ToLower()==" iii")
                {
                    name=name.Substring(0, name.Length-4)+name.Substring(name.Length-4, 4).ToUpper();
                }
                else if(name.Substring(name.Length-3).ToLower()==" iv")
                {
                    name=name.Substring(0, name.Length-3)+name.Substring(name.Length-3, 3).ToUpper();
                }
            }
            return name;
        }
    }
}
