﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.3.0.0
//      SpecFlow Generator Version:2.3.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace VolleyManagement.Specs.PlayersContext
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class CreatePlayerFeature : Xunit.IClassFixture<CreatePlayerFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "CreatePlayer.feature"
#line hidden
        
        public CreatePlayerFeature(CreatePlayerFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Create Player", "\tAs a tournament administrator\r\n\tI want to be able to create players\r\n    So they" +
                    " can be assigned to teams", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Create very long name")]
        [Xunit.TraitAttribute("FeatureTitle", "Create Player")]
        [Xunit.TraitAttribute("Description", "Create very long name")]
        public virtual void CreateVeryLongName()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create very long name", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
testRunner.Given("first name set to Very looong name which should be more than 60 symbols", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
testRunner.When("I execute CreatePlayer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
testRunner.Then("InvalidEntityException is thrown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.TheoryAttribute(DisplayName="Create simple player")]
        [Xunit.TraitAttribute("FeatureTitle", "Create Player")]
        [Xunit.TraitAttribute("Description", "Create simple player")]
        [Xunit.InlineDataAttribute("Marcuss", "Nilsson", new string[0])]
        [Xunit.InlineDataAttribute("Ivan", "Ivanov", new string[0])]
        public virtual void CreateSimplePlayer(string firstName, string lastName, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create simple player", exampleTags);
#line 11
this.ScenarioSetup(scenarioInfo);
#line 12
 testRunner.Given(string.Format("first name is {0}", firstName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 13
    testRunner.And(string.Format("last name is {0}", lastName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.When("I execute CreatePlayer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
    testRunner.Then("new player gets new Id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
 testRunner.Then("new player should be succesfully added", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.TheoryAttribute(DisplayName="Create player with all attributes")]
        [Xunit.TraitAttribute("FeatureTitle", "Create Player")]
        [Xunit.TraitAttribute("Description", "Create player with all attributes")]
        [Xunit.InlineDataAttribute("John", "Smith", "190", "85", "1985", new string[0])]
        [Xunit.InlineDataAttribute("Jane", "Doe", "180", "55", "1995", new string[0])]
        public virtual void CreatePlayerWithAllAttributes(string firstName, string lastName, string height, string weight, string birthYear, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create player with all attributes", exampleTags);
#line 23
this.ScenarioSetup(scenarioInfo);
#line 24
 testRunner.Given(string.Format("first name is {0}", firstName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 25
    testRunner.And(string.Format("last name is {0}", lastName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
    testRunner.And(string.Format("height is {0}", height), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
    testRunner.And(string.Format("weight is {0}", weight), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
    testRunner.And(string.Format("year of birth is {0}", birthYear), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.When("I execute CreatePlayer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
    testRunner.Then("new player gets new Id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 31
 testRunner.Then("new player should be succesfully added", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Quick create players from names")]
        [Xunit.TraitAttribute("FeatureTitle", "Create Player")]
        [Xunit.TraitAttribute("Description", "Quick create players from names")]
        public virtual void QuickCreatePlayersFromNames()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Quick create players from names", ((string[])(null)));
#line 37
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "FullName"});
            table1.AddRow(new string[] {
                        "John Smith"});
            table1.AddRow(new string[] {
                        "Peter Petrovich Petrov"});
#line 38
    testRunner.Given("set full names from Table", ((string)(null)), table1, "Given ");
#line 42
    testRunner.When("I execute QuickCreatePlayer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "FirstName",
                        "LastName"});
            table2.AddRow(new string[] {
                        "John",
                        "Smith"});
            table2.AddRow(new string[] {
                        "Peter Petrovich",
                        "Petrov"});
#line 43
    testRunner.Then("players is created from Table with FirstName and LastName", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Bulk create players")]
        [Xunit.TraitAttribute("FeatureTitle", "Create Player")]
        [Xunit.TraitAttribute("Description", "Bulk create players")]
        public virtual void BulkCreatePlayers()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Bulk create players", ((string[])(null)));
#line 48
this.ScenarioSetup(scenarioInfo);
#line 49
    testRunner.Given("collection of players to create", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 50
    testRunner.When("I execute CreatePlayerBulk", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 51
    testRunner.Then("all players are created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                CreatePlayerFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                CreatePlayerFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
