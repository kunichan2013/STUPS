﻿/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 3/15/2013
 * Time: 11:58 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of Wizard.
    /// </summary>
    public class Wizard
    {
        public Wizard(string name)
        {
            this.Name = name;
            this.Steps = new List<WizardStep>();
            WizardCollection.Wizards.Add(this);
        }
        
        public string Name { get; set; }
        public List<WizardStep> Steps { get; set; }
        public ScriptBlock[] StartAction { get; set; }
        //public ScriptBlock[] StopAction { get; set; }
        // 20130317
        public ScriptBlock[] StopAction { get; set; }
        // 20130317
        public ScriptBlock[] DefaultStepForwardAction { get; set; }
        // 20130317
        public ScriptBlock[] DefaultStepBackwardAction { get; set; }
        // 20130317
        public ScriptBlock[] DefaultStepCancelAction { get; set; }
        // 20130317
        public ScriptBlock[] DefaultStepGetWindowAction { get; set; }
        // 20130317
        public bool Automatic { get; set; }
        // 20130317
        public bool ForwardDirection { get; set; }
        
        public void ClearSteps()
        {
            this.Steps = new List<WizardStep>();
        }
        
        public void ClearStepsData()
        {
            foreach (WizardStep step in this.Steps) {
                
                step.StepForwardAction = null;
                step.StepBackwardAction = null;
            }
        }
        
        public void ClearStepsData(bool forward, bool backward)
        {
            foreach (WizardStep step in this.Steps) {
                
                if (forward) {
                    step.StepForwardAction = null;
                }
                if (backward) {
                    step.StepBackwardAction = null;
                }
            }
        }
        
        public WizardStep GetActiveStep()
        {
        	WizardStep resultStep = null;
        	
        	GetControlCmdletBase cmdletCtrl =
        		new GetControlCmdletBase();
        	
        	cmdletCtrl.InputObject =
        		new AutomationElement[]{ CurrentData.CurrentWindow };
        	cmdletCtrl.Timeout = 0;
        	
        	foreach (WizardStep step in this.Steps) {
				
        		cmdletCtrl.SearchCriteria = step.SearchCriteria;
        		
	        	ArrayList controlsList = null;
	        	
	        	try {
	        		controlsList =
	        			cmdletCtrl.getControl(cmdletCtrl);
	        	}
	        	catch {}
        		
	        	if (null != controlsList && 0 < controlsList.Count) {
	        		
	        		resultStep = step;
	        		break;
	        	}
        	}
        	
        	return resultStep;
        }
    }
}
