using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Facade
{
    class CompanyFacade
    {
        Designer _designer;
        DeveloperDotNet _developer;
        ProjectManager _pm;
        Tester _tester;

        public CompanyFacade()
        {
            _designer = new Designer();
            _developer = new DeveloperDotNet();
            _pm = new ProjectManager();
            _tester = new Tester();
        }

        public void CreateProductWithDesign()
        {
            _designer.CreateDesign();
            _pm.GetAssigmet();
            _developer.WorkIsDone();
            _tester.ResultOfTesting();
            _pm.VerifyProduct();
        }
        public void CreateProductWithoutDesign()
        {
            _pm.GetAssigmet();
            _developer.WorkIsDone();
            _tester.ResultOfTesting();
            _pm.VerifyProduct();
        }
        public void CreateSmallProduct()
        {
            _developer.WorkIsDone();
        }
        public void CreateBigProduct()
        {
            _designer.CreateDesign();
            _pm.GetAssigmet();
            _developer.WorkIsDone();
            _tester.ResultOfTesting();
            _developer.WorkIsDone();
            _designer.UpgradeDesign();
            _pm.GetAssigmet();
            _pm.VerifyProduct();
        }
    }
}
