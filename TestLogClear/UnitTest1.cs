using AppHealth;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.Windows;
using System;
using System.Windows.Forms;
using System.Windows.Media;
using AppHealth.sdkPage;


namespace TestLogClear

{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]

        public void TestAppStart()
        {
            // Arrange
            Window window = new Window();

            // Act
            window.Show(); // открываем окно
            window.Close(); // закрываем окно

            // Assert
            Assert.IsFalse(window.IsVisible); // проверяем, что окно больше не отображается

        }
        
    }
}