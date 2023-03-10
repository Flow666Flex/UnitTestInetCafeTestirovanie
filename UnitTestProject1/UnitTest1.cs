using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Windows.Forms;
using ИнтернетКафе;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Authorization_ReturnsRoleName_WhenLoginAndPasswordCorrect()
        {
            // Arrange
            string expectedRoleName = "Администратор";
            string login = "dimalogin";
            string password = "dimapassword";

            // Act
            string actualRoleName = Database.Authorization(login, password);

            // Assert
            Assert.AreEqual(expectedRoleName, actualRoleName);
        }

        [TestMethod]
        public void Authorization_ReturnsEmptyString_WhenLoginOrPasswordIncorrect()
        {
            // Arrange
            string expectedRoleName = "";
            string login = "wronglogin";
            string password = "wrongpassword";

            // Act
            string actualRoleName = Database.Authorization(login, password);

            // Assert
            Assert.AreEqual(expectedRoleName, actualRoleName);
        }

        [TestMethod]
        public void FormProduct_Load_Should_Fill_DataGridView_WithData()
        {
            // Arrange
            var formProduct = new FormProduct("Администратор");

            // Act
            formProduct.FormProduct_Load(this, EventArgs.Empty);

            // Assert
            Assert.IsTrue(formProduct.dataproducttable.Rows.Count > 0);
        }

        [TestMethod]
        public void FormProduct_Load_Should_Disable_AddProductButton_For_User_Role_Client()
        {
            // Arrange
            var formProduct = new FormProduct("Клиент");

            // Act
            formProduct.FormProduct_Load(this, EventArgs.Empty);

            // Assert
            Assert.IsFalse(formProduct.buttonaddproduct.Enabled);
            Assert.IsFalse(formProduct.buttonaddproduct.Visible);
        }
            [TestMethod]
            public void TestFormAuto()
            {
                // Arrange
                var formAuto = new FormAuto();
                var loginTextBox = formAuto.Controls["tbLogin"] as TextBox;
                var passwordTextBox = formAuto.Controls["tbPassword"] as TextBox;
                loginTextBox.Text = "admin";
                passwordTextBox.Text = "admin";

                // Act
                formAuto.buttonVHOD.PerformClick();

            // Assert
            var formProduct = Application.OpenForms.OfType<FormProduct>().FirstOrDefault();
            Assert.IsNull(formProduct);
        }
        }
    }

