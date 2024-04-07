using Core.DBContext;
using Core.Entities;
using Microsoft.IdentityModel.Tokens;
using Repositories.Repositories;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WinFormUI
{
    public partial class Form1 : Form
    {
        public DBEFContext eFContext = new DBEFContext();
        public CustomerRepository _customerRepository = new CustomerRepository();
        public EmployeeRepository _employeeRepository = new EmployeeRepository();
        public FuelingStationRepository _fuelingStationRepository = new FuelingStationRepository();
        public FuelInventoryRepository _fuelInventoryRepository = new FuelInventoryRepository();
        public FuelTypeRepository _fuelTypeRepository = new FuelTypeRepository();
        public OrderRepository _orderRepository = new OrderRepository();
        public SaleRepository _saleRepository = new SaleRepository();
        public TransactionRepository _transactionRepository = new TransactionRepository();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            _customerRepository.Add(new Customer
            {
                FullName = textBox1.Text,
                ContactInformation = textBox2.Text,
                OtherDetails = textBox3.Text,
            });
            UpdateList();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string selectedString = listBox1.SelectedItem.ToString();
            string[] words = selectedString.Split(", ");
            var cus = _customerRepository.Get(int.Parse(words[0]));
            if (cus != null)
            {
                cus.FullName = textBox1.Text;
                cus.ContactInformation = textBox2.Text;
                cus.OtherDetails = textBox3.Text;
                _customerRepository.Update(cus);
            }
            UpdateList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string selectedString = listBox1.SelectedItem.ToString();
            string[] words = selectedString.Split(", ");
            var cus = _customerRepository.Get(int.Parse(words[0]));
            if (cus != null)
            {
                _customerRepository.Delete(cus.Id);
            }
            UpdateList();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateList();
        }
        private void UpdateList()
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(_customerRepository.GetAll().ToArray());
            listBox2.Items.Clear();
            listBox2.Items.AddRange(_employeeRepository.GetAll().ToArray());
            listBox3.Items.Clear();
            listBox3.Items.AddRange(_fuelingStationRepository.GetAll().ToArray());
            listBox4.Items.Clear();
            listBox4.Items.AddRange(_fuelInventoryRepository.GetAll().ToArray());
            listBox5.Items.Clear();
            listBox5.Items.AddRange(_fuelTypeRepository.GetAll().ToArray());
            listBox6.Items.Clear();
            listBox6.Items.AddRange(_orderRepository.GetAll().ToArray());
            listBox7.Items.Clear();
            listBox7.Items.AddRange(_saleRepository.GetAll().ToArray());
            listBox8.Items.Clear();
            listBox8.Items.AddRange(_transactionRepository.GetAll().ToArray());
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(_fuelingStationRepository.GetAll().ToArray());
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(_fuelTypeRepository.GetAll().ToArray());
            comboBox3.Items.Clear();
            comboBox3.Items.AddRange(_customerRepository.GetAll().ToArray());
            comboBox6.Items.Clear();
            comboBox6.Items.AddRange(_customerRepository.GetAll().ToArray());
            comboBox7.Items.Clear();
            comboBox7.Items.AddRange(_employeeRepository.GetAll().ToArray());
            comboBox4.Items.Clear();
            comboBox4.Items.AddRange(_transactionRepository.GetAll().ToArray());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(_customerRepository.GetAll().ToArray());
        }
        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            if (!textBox6.Text.IsNullOrEmpty() && !textBox7.Text.IsNullOrEmpty())
            {
                var cus = _customerRepository.GetAll().Where(w => w.FullName.Contains(textBox6.Text) && w.ContactInformation.Contains(textBox7.Text));
                if (cus != null)
                {
                    listBox1.Items.AddRange(cus.ToArray());
                }
            }
            else if (textBox6.Text.IsNullOrEmpty() && !textBox7.Text.IsNullOrEmpty())
            {
                var cus = _customerRepository.GetAll().Where(w => w.ContactInformation.Contains(textBox7.Text));
                if (cus != null)
                {
                    listBox1.Items.AddRange(cus.ToArray());
                }
            }
            else if (!textBox6.Text.IsNullOrEmpty() && textBox7.Text.IsNullOrEmpty())
            {
                var cus = _customerRepository.GetAll().Where(w => w.FullName.Contains(textBox6.Text));
                if (cus != null)
                {
                    listBox1.Items.AddRange(cus.ToArray());
                }
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            _employeeRepository.Add(new Employee
            {
                FullName = textBox10.Text,
                Position = textBox11.Text,
                ContactInformation = textBox12.Text,
                OtherDetails = textBox13.Text,
            });
            UpdateList();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string selectedString = listBox2.SelectedItem.ToString();
            string[] words = selectedString.Split(", ");
            var emp = _employeeRepository.Get(int.Parse(words[0]));
            if (emp != null)
            {
                emp.FullName = textBox10.Text;
                emp.Position = textBox11.Text;
                emp.ContactInformation = textBox12.Text;
                emp.OtherDetails = textBox13.Text;
                _employeeRepository.Update(emp);
            }
            UpdateList();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string selectedString = listBox2.SelectedItem.ToString();
            string[] words = selectedString.Split(", ");
            var emp = _employeeRepository.Get(int.Parse(words[0]));
            if (emp != null)
            {
                _employeeRepository.Delete(emp.Id);
            }
            UpdateList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();

            if (!textBox8.Text.IsNullOrEmpty() && !textBox9.Text.IsNullOrEmpty())
            {
                var cus = _employeeRepository.GetAll().Where(w => w.FullName.Contains(textBox8.Text) && w.ContactInformation.Contains(textBox9.Text));
                if (cus != null)
                {
                    listBox2.Items.AddRange(cus.ToArray());
                }
            }
            else if (textBox8.Text.IsNullOrEmpty() && !textBox9.Text.IsNullOrEmpty())
            {
                var cus = _employeeRepository.GetAll().Where(w => w.ContactInformation.Contains(textBox9.Text));
                if (cus != null)
                {
                    listBox2.Items.AddRange(cus.ToArray());
                }
            }
            else if (!textBox8.Text.IsNullOrEmpty() && textBox9.Text.IsNullOrEmpty())
            {
                var cus = _employeeRepository.GetAll().Where(w => w.FullName.Contains(textBox8.Text));
                if (cus != null)
                {
                    listBox2.Items.AddRange(cus.ToArray());
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox2.Items.AddRange(_employeeRepository.GetAll().ToArray());
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
        }

        private void button13_Click(object sender, EventArgs e)
        {
            _fuelingStationRepository.Add(new FuelingStation
            {
                Location = textBox17.Text,
                SupportedFuelTypes = textBox18.Text,
                NumberOfDepots = int.Parse(textBox19.Text),
                OtherTechnicalDetails = textBox20.Text,
            });
            UpdateList();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string selectedString = listBox3.SelectedItem.ToString();
            string[] words = selectedString.Split(", ");
            var fs = _fuelingStationRepository.Get(int.Parse(words[0]));
            if (fs != null)
            {
                fs.Location = textBox17.Text;
                fs.SupportedFuelTypes = textBox18.Text;
                fs.NumberOfDepots = int.Parse(textBox19.Text);
                fs.OtherTechnicalDetails = textBox20.Text;
                _fuelingStationRepository.Update(fs);
            }
            UpdateList();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string selectedString = listBox3.SelectedItem.ToString();
            string[] words = selectedString.Split(", ");
            var emp = _fuelingStationRepository.Get(int.Parse(words[0]));
            if (emp != null)
            {
                _fuelingStationRepository.Delete(emp.Id);
            }
            UpdateList();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();

            if (!textBox15.Text.IsNullOrEmpty() && !textBox16.Text.IsNullOrEmpty())
            {
                var cus = _fuelingStationRepository.GetAll().Where(w => w.Location.Contains(textBox15.Text) && w.SupportedFuelTypes.Contains(textBox16.Text));
                if (cus != null)
                {
                    listBox3.Items.AddRange(cus.ToArray());
                }
            }
            else if (textBox15.Text.IsNullOrEmpty() && !textBox16.Text.IsNullOrEmpty())
            {
                var cus = _fuelingStationRepository.GetAll().Where(w => w.SupportedFuelTypes.Contains(textBox16.Text));
                if (cus != null)
                {
                    listBox3.Items.AddRange(cus.ToArray());
                }
            }
            else if (!textBox15.Text.IsNullOrEmpty() && textBox16.Text.IsNullOrEmpty())
            {
                var cus = _fuelingStationRepository.GetAll().Where(w => w.Location.Contains(textBox15.Text));
                if (cus != null)
                {
                    listBox3.Items.AddRange(cus.ToArray());
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            listBox3.Items.AddRange(_fuelingStationRepository.GetAll().ToArray());
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {
        }

        private void button18_Click(object sender, EventArgs e)
        {
            string[] words = comboBox2.Text.Split(", ");
            var ft = _fuelTypeRepository.Get(int.Parse(words[0]));
            if (ft != null)
            {
                _fuelInventoryRepository.Add(new FuelInventory
                {
                    QuantityAvailable = decimal.Parse(textBox24.Text),
                    LastUpdateDateTime = dateTimePicker1.Value,
                    MinStockLevel = decimal.Parse(textBox26.Text),
                    OtherDetails = textBox27.Text,
                    FuelType = new FuelType() { Name = ft.Name, UnitOfMeasurement = ft.UnitOfMeasurement, PricePerUnit = ft.PricePerUnit, FuelingStation = new FuelingStation() { Location = ft.FuelingStation.Location, NumberOfDepots = ft.FuelingStation.NumberOfDepots, OtherTechnicalDetails = ft.FuelingStation.OtherTechnicalDetails, SupportedFuelTypes = ft.FuelingStation.SupportedFuelTypes } },
                });
                UpdateList();
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string selectedString = listBox4.SelectedItem.ToString();
            string[] words = selectedString.Split(", ");
            var ft = _fuelInventoryRepository.Get(int.Parse(words[0]));
            if (ft != null)
            {
                string[] str = comboBox2.Text.Split(", ");
                var fs = _fuelTypeRepository.Get(int.Parse(str[0]));
                if (fs != null)
                {
                    ft.QuantityAvailable = decimal.Parse(textBox24.Text);
                    ft.LastUpdateDateTime = dateTimePicker1.Value;
                    ft.MinStockLevel = decimal.Parse(textBox26.Text);
                    ft.OtherDetails = textBox27.Text;
                    ft.FuelType = new FuelType() { Name = fs.Name, UnitOfMeasurement = fs.UnitOfMeasurement, PricePerUnit = fs.PricePerUnit, FuelingStation = new FuelingStation() { Location = fs.FuelingStation.Location, NumberOfDepots = fs.FuelingStation.NumberOfDepots, OtherTechnicalDetails = fs.FuelingStation.OtherTechnicalDetails, SupportedFuelTypes = fs.FuelingStation.SupportedFuelTypes } };
                    _fuelInventoryRepository.Update(ft);
                }
                UpdateList();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            string selectedString = listBox4.SelectedItem.ToString();
            string[] words = selectedString.Split(", ");
            var emp = _fuelInventoryRepository.Get(int.Parse(words[0]));
            if (emp != null)
            {
                _fuelInventoryRepository.Delete(emp.Id);
            }
            UpdateList();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();

            if (!textBox22.Text.IsNullOrEmpty())
            {
                var cus = _fuelInventoryRepository.GetAll().Where(w => w.OtherDetails.Contains(textBox22.Text));
                if (cus != null)
                {
                    listBox4.Items.AddRange(cus.ToArray());
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();
            listBox4.Items.AddRange(_fuelInventoryRepository.GetAll().ToArray());
        }

        private void button23_Click(object sender, EventArgs e)
        {

            string[] words = comboBox1.Text.Split(", ");
            var fs = _fuelingStationRepository.Get(int.Parse(words[0]));
            if (fs != null)
            {
                _fuelTypeRepository.Add(new FuelType
                {
                    Name = textBox31.Text,
                    UnitOfMeasurement = textBox32.Text,
                    PricePerUnit = int.Parse(textBox33.Text),
                    FuelingStation = new FuelingStation() { Location = fs.Location, NumberOfDepots = fs.NumberOfDepots, OtherTechnicalDetails = fs.OtherTechnicalDetails, SupportedFuelTypes = fs.SupportedFuelTypes },
                });
                UpdateList();
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            string selectedString = listBox5.SelectedItem.ToString();
            string[] words = selectedString.Split(", ");
            var ft = _fuelTypeRepository.Get(int.Parse(words[0]));
            if (ft != null)
            {
                string[] str = comboBox1.Text.Split(", ");
                var fs = _fuelingStationRepository.Get(int.Parse(str[0]));
                if (fs != null)
                {
                    ft.Name = textBox31.Text;
                    ft.UnitOfMeasurement = textBox32.Text;
                    ft.PricePerUnit = int.Parse(textBox33.Text);
                    ft.FuelingStation = new FuelingStation() { Location = fs.Location, NumberOfDepots = fs.NumberOfDepots, OtherTechnicalDetails = fs.OtherTechnicalDetails, SupportedFuelTypes = fs.SupportedFuelTypes };
                    _fuelTypeRepository.Update(ft);
                }
                UpdateList();
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            string selectedString = listBox5.SelectedItem.ToString();
            string[] words = selectedString.Split(", ");
            var emp = _fuelTypeRepository.Get(int.Parse(words[0]));
            if (emp != null)
            {
                _fuelTypeRepository.Delete(emp.Id);
            }
            UpdateList();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            listBox5.Items.Clear();

            if (!textBox29.Text.IsNullOrEmpty() && !textBox30.Text.IsNullOrEmpty())
            {
                var cus = _fuelTypeRepository.GetAll().Where(w => w.Name.Contains(textBox29.Text) && w.UnitOfMeasurement.Contains(textBox30.Text));
                if (cus != null)
                {
                    listBox5.Items.AddRange(cus.ToArray());
                }
            }
            else if (textBox29.Text.IsNullOrEmpty() && !textBox30.Text.IsNullOrEmpty())
            {
                var cus = _fuelTypeRepository.GetAll().Where(w => w.UnitOfMeasurement.Contains(textBox30.Text));
                if (cus != null)
                {
                    listBox5.Items.AddRange(cus.ToArray());
                }
            }
            else if (!textBox29.Text.IsNullOrEmpty() && textBox30.Text.IsNullOrEmpty())
            {
                var cus = _fuelTypeRepository.GetAll().Where(w => w.Name.Contains(textBox29.Text));
                if (cus != null)
                {
                    listBox5.Items.AddRange(cus.ToArray());
                }
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            listBox5.Items.Clear();
            listBox5.Items.AddRange(_fuelTypeRepository.GetAll().ToArray());
        }

        private void button28_Click(object sender, EventArgs e)
        {
            string[] words = comboBox3.Text.Split(", ");
            var fs = _customerRepository.Get(int.Parse(words[0]));
            if (fs != null)
            {
                _orderRepository.Add(new Order
                {
                    OrderDateTime = dateTimePicker2.Value,
                    TotalAmount = decimal.Parse(textBox39.Text),
                    OrderStatus = textBox40.Text,
                    Customer = new Customer() { FullName = fs.FullName, ContactInformation = fs.ContactInformation, OtherDetails = fs.OtherDetails },
                });
                UpdateList();
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            string selectedString = listBox6.SelectedItem.ToString();
            string[] words = selectedString.Split(", ");
            var ft = _orderRepository.Get(int.Parse(words[0]));
            if (ft != null)
            {
                string[] str = comboBox3.Text.Split(", ");
                var fs = _customerRepository.Get(int.Parse(str[0]));
                if (fs != null)
                {
                    ft.OrderDateTime = dateTimePicker2.Value;
                    ft.TotalAmount = decimal.Parse(textBox39.Text);
                    ft.OrderStatus = textBox40.Text;
                    ft.Customer = new Customer() { FullName = fs.FullName, ContactInformation = fs.ContactInformation, OtherDetails = fs.OtherDetails };
                    _orderRepository.Update(ft);
                }
                UpdateList();
            }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            string selectedString = listBox6.SelectedItem.ToString();
            string[] words = selectedString.Split(", ");
            var emp = _orderRepository.Get(int.Parse(words[0]));
            if (emp != null)
            {
                _orderRepository.Delete(emp.Id);
            }
            UpdateList();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            listBox6.Items.Clear();

            if (!textBox36.Text.IsNullOrEmpty())
            {
                var cus = _orderRepository.GetAll().Where(w => w.OrderStatus.Contains(textBox36.Text));
                if (cus != null)
                {
                    listBox6.Items.AddRange(cus.ToArray());
                }
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            listBox6.Items.Clear();
            listBox6.Items.AddRange(_orderRepository.GetAll().ToArray());
        }

        private void button33_Click(object sender, EventArgs e)
        {
            string[] words = comboBox4.Text.Split(", ");
            var fs = _transactionRepository.Get(int.Parse(words[0]));
            if (fs != null)
            {
                _saleRepository.Add(new Sale
                {
                    SaleAmount = decimal.Parse(textBox45.Text),
                    OtherSaleDetails = textBox46.Text,
                    Transaction = new Core.Entities.Transaction() { DateTime = fs.DateTime, Amount = fs.Amount, Quantity = fs.Quantity, OtherDetails = fs.OtherDetails, Customer = new Customer() { FullName = fs.Customer.FullName, ContactInformation = fs.Customer.ContactInformation, OtherDetails = fs.Customer.OtherDetails }, Employee = new Employee() { FullName = fs.Employee.FullName, Position = fs.Employee.Position, ContactInformation = fs.Employee.ContactInformation, OtherDetails = fs.Employee.OtherDetails } },
                });
                UpdateList();
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            string selectedString = listBox7.SelectedItem.ToString();
            string[] words = selectedString.Split(", ");
            var ft = _saleRepository.Get(int.Parse(words[0]));
            if (ft != null)
            {
                string[] words2 = comboBox4.Text.Split(", ");
                var fs = _transactionRepository.Get(int.Parse(words2[0]));
                if (fs != null)
                {
                    ft.SaleAmount = decimal.Parse(textBox45.Text);
                    ft.OtherSaleDetails = textBox46.Text;
                    ft.Transaction = new Core.Entities.Transaction() { DateTime = fs.DateTime, Amount = fs.Amount, Quantity = fs.Quantity, OtherDetails = fs.OtherDetails, Customer = new Customer() { FullName = fs.Customer.FullName, ContactInformation = fs.Customer.ContactInformation, OtherDetails = fs.Customer.OtherDetails }, Employee = new Employee() { FullName = fs.Employee.FullName, Position = fs.Employee.Position, ContactInformation = fs.Employee.ContactInformation, OtherDetails = fs.Employee.OtherDetails } };
                    _saleRepository.Update(ft);
                }
                UpdateList();
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            string selectedString = listBox7.SelectedItem.ToString();
            string[] words = selectedString.Split(", ");
            var emp = _saleRepository.Get(int.Parse(words[0]));
            if (emp != null)
            {
                _saleRepository.Delete(emp.Id);
            }
            UpdateList();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            listBox7.Items.Clear();

            if (!textBox44.Text.IsNullOrEmpty())
            {
                var cus = _saleRepository.GetAll().Where(w => w.OtherSaleDetails.Contains(textBox44.Text));
                if (cus != null)
                {
                    listBox7.Items.AddRange(cus.ToArray());
                }
            }
            UpdateList();
        }
        private void button31_Click(object sender, EventArgs e)
        {
            listBox7.Items.Clear();
            listBox7.Items.AddRange(_saleRepository.GetAll().ToArray());
        }

        private void button38_Click(object sender, EventArgs e)
        {
            string[] words = comboBox6.Text.Split(", ");
            var fc = _customerRepository.Get(int.Parse(words[0]));
            string[] str = comboBox7.Text.Split(", ");
            var fe = _employeeRepository.Get(int.Parse(str[0]));
            if (fc != null && fe != null)
            {
                _transactionRepository.Add(new Core.Entities.Transaction
                {
                    DateTime = dateTimePicker3.Value,
                    Amount = decimal.Parse(textBox53.Text),
                    Quantity = decimal.Parse(textBox54.Text),
                    OtherDetails = textBox55.Text,
                    Customer = new Customer() { FullName = fc.FullName, ContactInformation = fc.ContactInformation, OtherDetails = fc.OtherDetails },
                    Employee = new Employee() { FullName = fe.FullName, Position = fe.Position, ContactInformation = fe.ContactInformation, OtherDetails = fe.OtherDetails },
                });
                UpdateList();
            }
        }

        private void button39_Click(object sender, EventArgs e)
        {
            string selectedString = listBox8.SelectedItem.ToString();
            string[] words = selectedString.Split(", ");
            var ft = _transactionRepository.Get(int.Parse(words[0]));
            if (ft != null)
            {
                string[] words2 = comboBox6.Text.Split(", ");
                var fc = _customerRepository.Get(int.Parse(words2[0]));
                string[] str = comboBox7.Text.Split(", ");
                var fe = _employeeRepository.Get(int.Parse(str[0]));
                if (fc != null && fe != null)
                {
                    ft.DateTime = dateTimePicker3.Value;
                    ft.Amount = decimal.Parse(textBox53.Text);
                    ft.Quantity = decimal.Parse(textBox54.Text);
                    ft.OtherDetails = textBox55.Text;
                    ft.Customer = new Customer() { FullName = fc.FullName, ContactInformation = fc.ContactInformation, OtherDetails = fc.OtherDetails };
                    ft.Employee = new Employee() { FullName = fe.FullName, Position = fe.Position, ContactInformation = fe.ContactInformation, OtherDetails = fe.OtherDetails };
                    _transactionRepository.Update(ft);
                }
                UpdateList();
            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            string selectedString = listBox8.SelectedItem.ToString();
            string[] words = selectedString.Split(", ");
            var emp = _transactionRepository.Get(int.Parse(words[0]));
            if (emp != null)
            {
                _transactionRepository.Delete(emp.Id);
            }
            UpdateList();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            listBox8.Items.Clear();

            if (!textBox51.Text.IsNullOrEmpty())
            {
                var cus = _transactionRepository.GetAll().Where(w => w.OtherDetails.Contains(textBox51.Text));
                if (cus != null)
                {
                    listBox8.Items.AddRange(cus.ToArray());
                }
            }
            UpdateList();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            listBox8.Items.Clear();
            listBox8.Items.AddRange(_saleRepository.GetAll().ToArray());
        }

        private void label49_Click(object sender, EventArgs e)
        {

        }

        private void textBox49_TextChanged(object sender, EventArgs e)
        {
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }
    }
}