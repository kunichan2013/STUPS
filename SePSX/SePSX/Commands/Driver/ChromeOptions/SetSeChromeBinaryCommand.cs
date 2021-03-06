﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/28/2012
 * Time: 9:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System.Management.Automation;

    /// <summary>
    /// Description of SetSeChromeBinaryCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "SeChromeBinary")]
    [OutputType(typeof(OpenQA.Selenium.Chrome.ChromeOptions))]
    public class SetSeChromeBinaryCommand : EditChromeOptionsCmdletBase
    {
        public SetSeChromeBinaryCommand()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true)]
        public string BinaryPath { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            // check input options
            CheckInputChromeOptions(true);
            
            // set the binary path
            var command =
                new SeSetChromeBinaryCommand(this);
            command.Execute();
        }
    }
}
