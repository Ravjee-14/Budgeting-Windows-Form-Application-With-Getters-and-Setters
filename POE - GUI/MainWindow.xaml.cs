using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

//Class to hold public abstracts 
abstract class Expenses
{
    public abstract double MonthlyExpenses();
    public abstract double Purchasing();
    public abstract double Renting();
    public abstract double Vehicle();
    public abstract double Savings();
}

//class MonthlyExpenses to hold expenses and also a Get and Set Method
class MonthlyExpenses
{
    public double Income
    { get; set; }

    public double TaxDeduct
    { get; set; }

    public double Groceries
    { get; set; }

    public double LightsAndWater
    { get; set; }

    public double TravelCosts
    { get; set; }

    public double CellPhone
    { get; set; }

    public double Miscellaneous
    { get; set; }

    public double GrossIncome
    { get; set; }
}

//class Purchasing to hold Get and Set method when user chooses to buy a propert
class Purchasing
{

    public double PurchasePrice
    { get; set; }

    public double Deposit
    { get; set; }

    public double IntRate
    { get; set; }

    public double RepayMonths
    { get; set; }

    public double RepaymentAmount
    { get; set; }
}

//Class renting to hold rentExpense get and set method
class Renting
{
    public double RentExpense
    { get; set; }
}

//Class vehicle to hold Get and Set methods used in Vehicle repayment
class Vehicle
{
    public String MakeAndModel
    { get; set; }

    public double VehiclePurchasePrice
    { get; set; }

    public double VehicleDeposit
    { get; set; }

    public double VehicleIntRate
    { get; set; }

    public double InsurancePremium
    { get; set; }

    public double MonthlyRepaymentIncInsurance
    { get; set; }
}

//Class Savings which holds Get and Set methods used in calculations
class Savings
{
    public string SavingsRef
    { get; set; }

    public double SavingsAmount
    { get; set; }

    public double SavingsPeriod
    { get; set; }

    public double SavingsIntRate
    { get; set; }

    public double MonthlySavings
    { get; set; }
}

namespace POE___GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Classes are declared into the main
        MonthlyExpenses myExpenses = new MonthlyExpenses();
        Purchasing myProperty = new Purchasing();
        Renting myRent = new Renting();
        Vehicle myVehicle = new Vehicle();
        Savings mySavings = new Savings();

        public MainWindow()
        {
            InitializeComponent();
        }

        //Gross income button class which calculates gross income after expenses
        private void btnGrossIncome_Click(object sender, RoutedEventArgs e)
        {
            //Try and catch for error handlings
            try
            {
                //Values from text box are declared to the corresponding class names
                myExpenses.Income = double.Parse(txtMonthlyIncome.Text);
                myExpenses.TaxDeduct = double.Parse(txtTaxDeduct.Text);
                myExpenses.Groceries = double.Parse(txtGrocery.Text);
                myExpenses.LightsAndWater = double.Parse(txtLightsAndWater.Text);
                myExpenses.TravelCosts = double.Parse(txtTravelCost.Text);
                myExpenses.CellPhone = double.Parse(txtCellPhone.Text);
                myExpenses.Miscellaneous = double.Parse(txtMiscellaneous.Text);

                //gross income after expenses calculation
                myExpenses.GrossIncome = myExpenses.Income - myExpenses.TaxDeduct - myExpenses.Groceries - myExpenses.LightsAndWater - myExpenses.TravelCosts - myExpenses.CellPhone - myExpenses.Miscellaneous;

                //Message box displaying expenses and remaining balance
                MessageBox.Show("---------------------------------------------------------------" +
                                "\nYour Monthly Income is ----------------------\t" + Math.Round(myExpenses.Income, 2) +
                                "\nYour Monthly Tax deductions is --------------\t" + Math.Round(myExpenses.TaxDeduct, 2) +
                                "\nYour Monthly Grocery Cost is ----------------\t" + Math.Round(myExpenses.Groceries, 2) +
                                "\nYour Monthly Travel cost is -----------------\t" + Math.Round(myExpenses.TravelCosts, 2) +
                                "\nYour Monthly Cell and Telephone cost is -----\t" + Math.Round(myExpenses.CellPhone, 2) +
                                "\nYour Monthly Miscellaneous Expenses is ------\t" + Math.Round(myExpenses.Miscellaneous, 2) +
                                "\n---------------------------------------------------------------" +
                                "\nYour Remaining balnce is --------------------\t" + Math.Round(myExpenses.GrossIncome, 2) +
                                "\n---------------------------------------------------------------");
            }
            //Catch with will display error message
            catch(Exception)
            {
                MessageBox.Show("Please enter a value in all fields" +
                                "\nPlease enter '0' if there is no value" +
                                "\nNo Special characters are allowed");
            }
        }

        //Renting button class which will show remaining balance after all expenses
        private void btnRenting_Click(object sender, RoutedEventArgs e)
        {
            //try and catch for error handling
            try
            {
                myExpenses.Income = double.Parse(txtMonthlyIncome.Text);
                myExpenses.TaxDeduct = double.Parse(txtTaxDeduct.Text);
                myExpenses.Groceries = double.Parse(txtGrocery.Text);
                myExpenses.LightsAndWater = double.Parse(txtLightsAndWater.Text);
                myExpenses.TravelCosts = double.Parse(txtTravelCost.Text);
                myExpenses.CellPhone = double.Parse(txtCellPhone.Text);
                myExpenses.Miscellaneous = double.Parse(txtMiscellaneous.Text);
                myRent.RentExpense = double.Parse(txtRentExpense.Text);

                //Calculation used to determine remaining balance
                double grossIncomeIncRent = myExpenses.Income - myExpenses.TaxDeduct - myExpenses.Groceries - myExpenses.LightsAndWater - myExpenses.TravelCosts - myExpenses.CellPhone - myExpenses.Miscellaneous - myRent.RentExpense;

                MessageBox.Show("---------------------------------------------------------------" +
                                "\nYour Monthly Income is ----------------------\t" + myExpenses.Income +
                                "\nYour Monthly Tax deductions is --------------\t" + myExpenses.TaxDeduct +
                                "\nYour Monthly Grocery Cost is ----------------\t" + myExpenses.Groceries +
                                "\nYour Monthly Travel cost is -----------------\t" + myExpenses.TravelCosts +
                                "\nYour Monthly Cell and Telephone cost is -----\t" + myExpenses.CellPhone +
                                "\nYour Monthly Miscellaneous Expenses is ------\t" + myExpenses.Miscellaneous +
                                "\nYour Monthly Rent Expense is ----------------\t" + myRent.RentExpense +
                                "\n---------------------------------------------------------------" +
                                "\nYour Remaining Balance is -------------------\t" + Math.Round(grossIncomeIncRent, 2) +
                                "\n---------------------------------------------------------------");
            }
            //Catch to display error message
            catch (Exception)
            {
                MessageBox.Show("Please enter a value in all fields" +
                                "\nPlease enter '0' if there is no value" +
                                "\nNo Special characters are allowed");
            }
        }

        //Monthly repayment button which calculates the monthly property repayment
        private void btnMonthlyRepay_Click(object sender, RoutedEventArgs e)
        {
            //try and catch for error handling
            try
            {
                myExpenses.Income = double.Parse(txtMonthlyIncome.Text);
                myExpenses.TaxDeduct = double.Parse(txtTaxDeduct.Text);
                myExpenses.Groceries = double.Parse(txtGrocery.Text);
                myExpenses.LightsAndWater = double.Parse(txtLightsAndWater.Text);
                myExpenses.TravelCosts = double.Parse(txtTravelCost.Text);
                myExpenses.CellPhone = double.Parse(txtCellPhone.Text);
                myExpenses.Miscellaneous = double.Parse(txtMiscellaneous.Text);

                myProperty.PurchasePrice = double.Parse(txtPurchasePrice.Text);
                myProperty.Deposit = double.Parse(txtDeposit.Text);
                myProperty.IntRate = double.Parse(txtInterestRate.Text);
                myProperty.RepaymentAmount = double.Parse(txtRepaymentPeriod.Text);
                myProperty.RepayMonths = double.Parse(txtRepaymentPeriod.Text);

                //Calculation for monthly repayment. Simple Interest formula is used
                double paymentExlDepo = myProperty.PurchasePrice - myProperty.Deposit;
                double totalCost = paymentExlDepo * (1 + (myProperty.IntRate / 100) * (myProperty.RepayMonths / 12));
                myProperty.RepaymentAmount = totalCost / myProperty.RepayMonths;

                //calculation to calculate remaining balance
                double grossIncomeIncMonthlyRepayment = myExpenses.Income - myExpenses.TaxDeduct - myExpenses.Groceries - myExpenses.LightsAndWater - myExpenses.TravelCosts - myExpenses.CellPhone - myExpenses.Miscellaneous - myProperty.RepaymentAmount;

                MessageBox.Show("---------------------------------------------------------------" +
                                "\nYour Monthly Income is ----------------------\t" + Math.Round(myExpenses.Income, 2)+
                                "\nYour Monthly Tax deductions is --------------\t" + Math.Round(myExpenses.TaxDeduct, 2) +
                                "\nYour Monthly Grocery Cost is ----------------\t" + Math.Round(myExpenses.Groceries, 2) +
                                "\nYour Monthly Travel cost is -----------------\t" + Math.Round(myExpenses.TravelCosts, 2) +
                                "\nYour Monthly Cell and Telephone cost is -----\t" + Math.Round(myExpenses.CellPhone, 2) +
                                "\nYour Monthly Miscellaneous Expenses is ------\t" + Math.Round(myExpenses.Miscellaneous, 2) +
                                "\nYour Monthly Property repayment is ----------\t" + Math.Round(myProperty.RepaymentAmount, 2) +
                                "\n---------------------------------------------------------------" +
                                "\nYour Remaining Balance is -------------------\t" + Math.Round(grossIncomeIncMonthlyRepayment, 2) +
                                "\n---------------------------------------------------------------");

                //If statement that displays when repayment amount is greater than a third of income
                if (myProperty.RepaymentAmount > myExpenses.Income / 3)
                {
                    MessageBox.Show("Your Home Loan Approval is Unlikey" +
                                    "\nReason - Monthly Repayments on Property Exceeds a third of gross income!!!");
                }
            }
            //Catch Statement to display error message
            catch (Exception)
            {
                MessageBox.Show("Please enter a value in all fields" +
                                "\nPlease enter '0' if there is no value Or Round off Decimal to nearest value" +
                                "\nNo Special characters are allowed");
            }

        }

        //Savings button class to calculate monthly savings
        private void btnSavings_Click(object sender, RoutedEventArgs e)
        {
            //try and catch statement to help with error handling
            try
            {
                mySavings.SavingsRef = txtSavingRef.Text;
                mySavings.SavingsAmount = double.Parse(txtSavingAmount.Text);
                mySavings.SavingsPeriod = double.Parse(txtSavingPeriod.Text);
                mySavings.SavingsIntRate = double.Parse(txtSavingIntRate.Text);

                //formual used to calculate monthly savings
                //this formula is simple interest calculating for principal value
                //compund interest was not used as they are saving money and not investing it 
                double principalAmount = mySavings.SavingsAmount / (1 + (mySavings.SavingsIntRate * mySavings.SavingsPeriod));
                mySavings.MonthlySavings = principalAmount / (mySavings.SavingsPeriod * 12);

                //message box displaying minimum value needed to reach goal
                MessageBox.Show("You will have to Save R" + Math.Round(mySavings.MonthlySavings, 2).ToString() + " a month to reach your goal");
            }
            //catch statement for error handling
            catch (Exception)
            {
                MessageBox.Show("Please enter a value in all fields" +
                                "\nPlease enter '0' if there is no value or Round off decimal to nearest value" +
                                "\nNo Special characters are allowed");
            }
        }

        //vehicle repayment button class for calculations
        private void btnVehRepayment_Click(object sender, RoutedEventArgs e)
        {
            //try and catch to help for error handlings
            try
            {
                myVehicle.MakeAndModel = txtVehMake.Text;
                myVehicle.VehiclePurchasePrice = double.Parse(txtVehPurchasePrice.Text);
                myVehicle.VehicleDeposit = double.Parse(txtVehDeposit.Text);
                myVehicle.VehicleIntRate = double.Parse(txtVehIntRate.Text);
                myVehicle.InsurancePremium = double.Parse(txtVehInsurance.Text);

                //calculation for car repayment
                //simple interest formual + insurance premium is used to calculate
                //depreciation was not used in the formual as they never gave depreciation percentage
                double totalPayment = (myVehicle.VehiclePurchasePrice - myVehicle.VehicleDeposit) * (1 + (myVehicle.VehicleIntRate / 100) * 5);
                double totalMonthlyRepayment = totalPayment / 60;
                myVehicle.MonthlyRepaymentIncInsurance = totalMonthlyRepayment + myVehicle.InsurancePremium;

                //message box to show monthly repayments
                MessageBox.Show("Your Monthly Repayment on a " + myVehicle.MakeAndModel + " is R" + Math.Round(myVehicle.MonthlyRepaymentIncInsurance, 2));
            }
            //catch statment to help with error handling
            catch (Exception)
            {
                MessageBox.Show("Please enter a value in all fields" +
                                "\nPlease enter '0' if there is no value" +
                                "\nNo Special characters are allowed");
            }
        }

        //calculate all button class
        private void btnCalcAll_Click(object sender, RoutedEventArgs e)
        {
            //try and catch to help with error handling
            try
            {
                //calculation to determine remaining balance
                double calcAll = myExpenses.GrossIncome - mySavings.MonthlySavings - myRent.RentExpense - myProperty.RepaymentAmount - myVehicle.MonthlyRepaymentIncInsurance;

                //if statement to give a specific output for purchasing
                if (radbtnPurchasing.IsChecked == true)
                {
                    //message box to display all expenses
                    MessageBox.Show("---------------------------------------------------------------" +
                                    "\nYour Gross Income Minus Expenses is --------\t" + Math.Round(myExpenses.GrossIncome, 2) +
                                    "\nYour Monthly savings is --------------------\t" + Math.Round(mySavings.MonthlySavings, 2) +
                                    "\nYour Repayment on Property is --------------\t" + Math.Round(myProperty.RepaymentAmount, 2) +
                                    "\nYour vehicle Repayment is ------------------\t" + Math.Round(myVehicle.MonthlyRepaymentIncInsurance, 2) +
                                    "\n--------------------------------------------------------------" +
                                    "\nYour Remaining balance is ------------------\t" + Math.Round(calcAll, 2) +
                                    "\n--------------------------------------------------------------");
                }
                //if statement to give a specific output for renting
                else if (radbtnRenting.IsChecked == true)
                {
                    //message box to display all expenses
                    MessageBox.Show("---------------------------------------------------------------" +
                                    "\nYour Gross Income Minus Expenses is ------\t" + Math.Round(myExpenses.GrossIncome, 2) +
                                    "\nYour Monthly savings is ------------------\t" + Math.Round(mySavings.MonthlySavings, 2) +
                                    "\nYour Rent Expense is  --------------------\t\t" + Math.Round(myRent.RentExpense, 2) +
                                    "\nYour vehicle Repayment is ----------------\t" + Math.Round(myVehicle.MonthlyRepaymentIncInsurance, 2) +
                                    "\n--------------------------------------------------------------" +
                                    "\nYour Remaining balance is ----------------\t" + Math.Round(calcAll, 2) +
                                    "\n--------------------------------------------------------------");
                }
                // if statement to show message box if remaining balance is negative
                if (calcAll < 0)
                {
                    MessageBox.Show("Your Remaining balance is Negative" +
                                    "\nCurrent car repayment is not reccomended");
                }
            }
            //catch if there is an error
            catch (Exception)
            {
                MessageBox.Show("Please enter a value in all fields" +
                                "\nPlease enter '0' if there is no value" +
                                "\nNo Special characters are allowed");
            }
        }

        //save to file button to save all values to file
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //try statement to tell user if a value has not been inputted
            try
            {
                // try statement to tell user if the file cannot be written
                try
                {
                    //destination to save file
                    //please enter save destination before starting the program
                    StreamWriter tw = new StreamWriter("C:\\");

                    //what will be written in the file
                    tw.Write("---------------------------------------------------------------" +
                             "\nYour Monthly Income is ----------------------\t" + myExpenses.Income +
                             "\nYour Monthly Tax deductions is --------------\t" + myExpenses.TaxDeduct +
                             "\nYour Monthly Grocery Cost is ----------------\t" + myExpenses.Groceries +
                             "\nYour Monthly Travel cost is -----------------\t" + myExpenses.TravelCosts +
                             "\nYour Monthly Cell and Telephone cost is -----\t" + myExpenses.CellPhone +
                             "\nYour Monthly Miscellaneous Expenses is ------\t" + myExpenses.Miscellaneous +
                             "\nYour Monthly Gross income is ----------------\t" + Math.Round(myExpenses.GrossIncome, 2) +
                             "\n---------------------------------------------------------------" +
                             "\nYour Vehicle Repayment is -------------------\t" + Math.Round(myVehicle.MonthlyRepaymentIncInsurance, 2) +
                             "\nYour Monthly savings is ---------------------\t" + Math.Round(mySavings.MonthlySavings, 2) +
                             "\nYour Rent Expense is  ---------------------\t\t" + Math.Round(myRent.RentExpense, 2) +
                             "\nYour Repayment on Property is ---------------\t" + Math.Round(myProperty.RepaymentAmount, 2) +
                             "\n---------------------------------------------------------------");
                    tw.Close();

                    MessageBox.Show("File has successfully been written");
                }
                //catch expception to display what went wrong
                catch (Exception)
                {
                    MessageBox.Show("Unable to Save to file" +
                                    "\nReason - Access Denied from System Firewall");
                }
            }
            //catch statment to tell user what is wrong
            catch (Exception)
            {
                MessageBox.Show("Please enter a value in all fields" +
                                "\nPlease enter '0' if there is no value" +
                                "\nNo Special characters are allowed");
            }
        }

        //radio button class to show or hide textboxes ,labels and buttons
        private void radbtnRenting_Checked(object sender, RoutedEventArgs e)
        {
            if(radbtnRenting.IsChecked == true)
            {
                this.lblRentExpense.Visibility = System.Windows.Visibility.Visible;
                this.txtRentExpense.Visibility = System.Windows.Visibility.Visible;

                this.lblPurchasePrice.Visibility = System.Windows.Visibility.Hidden;
                this.txtPurchasePrice.Visibility = System.Windows.Visibility.Hidden;
                this.lblDeposit.Visibility = System.Windows.Visibility.Hidden;
                this.txtDeposit.Visibility = System.Windows.Visibility.Hidden;
                this.lblIntRate.Visibility = System.Windows.Visibility.Hidden;
                this.txtInterestRate.Visibility = System.Windows.Visibility.Hidden;
                this.lblRepayment.Visibility = System.Windows.Visibility.Hidden;
                this.txtRepaymentPeriod.Visibility = System.Windows.Visibility.Hidden;

                this.btnRenting.Visibility = System.Windows.Visibility.Visible;
                this.btnMonthlyRepay.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        //radio button class to show or hide labels, text box or button
        private void radbtnPurchasing_Checked(object sender, RoutedEventArgs e)
        {
            if(radbtnPurchasing.IsChecked == true)
            {
                this.lblPurchasePrice.Visibility = System.Windows.Visibility.Visible;
                this.txtPurchasePrice.Visibility = System.Windows.Visibility.Visible;

                this.lblDeposit.Visibility = System.Windows.Visibility.Visible;
                this.txtDeposit.Visibility = System.Windows.Visibility.Visible;
                
                this.lblIntRate.Visibility = System.Windows.Visibility.Visible;
                this.txtInterestRate.Visibility = System.Windows.Visibility.Visible;

                this.lblRepayment.Visibility = System.Windows.Visibility.Visible;
                this.txtRepaymentPeriod.Visibility = System.Windows.Visibility.Visible;

                this.lblRentExpense.Visibility = System.Windows.Visibility.Hidden;
                this.txtRentExpense.Visibility = System.Windows.Visibility.Hidden;

                this.btnMonthlyRepay.Visibility = System.Windows.Visibility.Visible;
                this.btnRenting.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        //checkbox to hide or show, label, textbox or button. also to untick other textbox when one is checked
        private void chkboxYes_Checked(object sender, RoutedEventArgs e)
        {
            if(chkboxYes.IsChecked == true)
            {
                
                this.lblVehMakeAndModel.Visibility = System.Windows.Visibility.Visible;
                this.txtVehMake.Visibility = System.Windows.Visibility.Visible;

                this.lblVehPurchase.Visibility = System.Windows.Visibility.Visible;
                this.txtVehPurchasePrice.Visibility = System.Windows.Visibility.Visible;
                
                this.lblVehDeposit.Visibility = System.Windows.Visibility.Visible;
                this.txtVehDeposit.Visibility = System.Windows.Visibility.Visible;

                this.lblVehIntRate.Visibility = System.Windows.Visibility.Visible;
                this.txtVehIntRate.Visibility = System.Windows.Visibility.Visible;

                this.lblVehPremium.Visibility = System.Windows.Visibility.Visible;
                this.txtVehInsurance.Visibility = System.Windows.Visibility.Visible;

                this.btnVehRepayment.Visibility = System.Windows.Visibility.Visible;

                chkboxNo.IsChecked = false;

            }
        }

        //checkbox to hide or show, label, textbox or button. also to untick other textbox when one is checked
        private void chkboxNo_Checked(object sender, RoutedEventArgs e)
        {

            this.lblVehMakeAndModel.Visibility = System.Windows.Visibility.Hidden;
            this.txtVehMake.Visibility = System.Windows.Visibility.Hidden;

            this.lblVehPurchase.Visibility = System.Windows.Visibility.Hidden;
            this.txtVehPurchasePrice.Visibility = System.Windows.Visibility.Hidden;

            this.lblVehDeposit.Visibility = System.Windows.Visibility.Hidden;
            this.txtVehDeposit.Visibility = System.Windows.Visibility.Hidden;

            this.lblVehIntRate.Visibility = System.Windows.Visibility.Hidden;
            this.txtVehIntRate.Visibility = System.Windows.Visibility.Hidden;

            this.lblVehPremium.Visibility = System.Windows.Visibility.Hidden;
            this.txtVehInsurance.Visibility = System.Windows.Visibility.Hidden;

            this.btnVehRepayment.Visibility = System.Windows.Visibility.Hidden;

            chkboxYes.IsChecked = false;
        }
    }
}

/*References
C# Tutorial (2021). C# delegate tutorial. [Online] From: https://www.completecsharptutorial.com/basic/c-delegate-tutorial-with-easy-example.php
W3 Schools (2021) C# Exceptions. [Online] From: https://www.w3schools.com/cs/cs_exceptions.asp
Lionsure (2020) Bubble sort algorithm. [Online] From: http://www.liangshunet.com/en/202007/799693701.htm
TutorialsTeach (2021) Generic & Non-Generic collections. [Online] From: https://www.tutorialsteacher.com/csharp/csharp-collection
Chand. M (2020) C# Write to file. [Online] From: https://www.c-sharpcorner.com/article/c-sharp-write-to-file/
Microsoft (2010) Switch statment with radio button. [Online] From: https://social.msdn.microsoft.com/Forums/en-US/1eba7a7f-71c3-496b-b375-910a9510f7e0/switch-statement-with-radio-buttons?forum=Vsexpressvcs

*/