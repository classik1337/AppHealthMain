using AppHealth;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.Windows;
using System;
using System.Windows.Forms;
using System.Windows.Media;
using AppHealth;



namespace TestLogClear

{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]

           public void TestAppStart()
        {
            // Arrange
            var app = new App();

            // Act
            app.InitializeComponent();

            // Assert
            Assert.IsNotNull(app);
        }
        
    }
}