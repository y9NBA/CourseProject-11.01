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

namespace CP1101.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private static DataGrid dataGrid;

        private static string enterTable;

        public MainPage(string tableName="Пользователи")
        {
            InitializeComponent();

            dataGrid = getNewDataGrid();
            enterTable = tableName;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            EnterTable.ItemsSource = Database.getAllNameTables();
            EnterTable.SelectedItem = enterTable;
            
            updateDataGrid();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (enterTable == null)
            {
                MessageBox.Show("Не выбрана таблица!\nВыберите её.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Navigation.CurrentFrame.Navigate(new CreatePage(enterTable));
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (!isSelectedEntity()) 
                return;

            Object entity = dataGrid.SelectedItem;
            Navigation.CurrentFrame.Navigate(new EditPage(EnterTable.SelectedItem.ToString(), entity));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (!isSelectedEntity())
                return;

            switch (enterTable)
            {
                case "Пользователи":
                    Database.Instance.Пользователи.Remove(dataGrid.SelectedItem as Пользователи);
                    break;
                case "Сотрудники":
                    Database.Instance.Сотрудники.Remove(dataGrid.SelectedItem as Сотрудники);
                    break;
                case "Должности":
                    Database.Instance.Должности.Remove(dataGrid.SelectedItem as Должности);
                    break;
                case "Отделы":
                    Database.Instance.Отделы.Remove(dataGrid.SelectedItem as Отделы);
                    break;
                case "Навыки":
                    Database.Instance.Навыки.Remove(dataGrid.SelectedItem as Навыки);
                    break;
                case "Сертификаты":
                    Database.Instance.Сертификаты.Remove(dataGrid.SelectedItem as Сертификаты);
                    break;
                case "Образование":
                    Database.Instance.Образование.Remove(dataGrid.SelectedItem as Образование);
                    break;
                case "Контакты":
                    Database.Instance.Контакты.Remove(dataGrid.SelectedItem as Контакты);
                    break;
                case "История работы":
                    Database.Instance.История_работы.Remove(dataGrid.SelectedItem as История_работы);
                    break;
                case "Заработная плата":
                    Database.Instance.Заработная_плата.Remove(dataGrid.SelectedItem as Заработная_плата);
                    break;
                case "График работы":
                    Database.Instance.График_работы.Remove(dataGrid.SelectedItem as График_работы);
                    break;
            }

            Database.save();

            updateDataGrid();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Navigation.CurrentFrame.Navigate(new AuthPage());
        }

        private void EnterTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            enterTable = EnterTable.SelectedItem.ToString();

            updateDataGrid();
        }

        private void updateDataGrid()
        {
            DataPanel.Children.Clear();

            dataGrid = getNewDataGrid();

            switch (enterTable)
            {
                case "Пользователи":
                    setUserDataGrid(dataGrid);
                    break;
                case "Сотрудники":
                    setEmployeeDataGrid(dataGrid);
                    break;
                case "Должности":
                    setPositionDataGrid(dataGrid);
                    break;
                case "Отделы":
                    setDepartmentDataGrid(dataGrid);
                    break;
                case "Навыки":
                    setSkillDataGrid(dataGrid);
                    break;
                case "Сертификаты":
                    setCertificateDataGrid(dataGrid);
                    break;
                case "Образование":
                    setEducationDataGrid(dataGrid);
                    break;
                case "Контакты":
                    setContactDataGrid(dataGrid);
                    break;
                case "История работы":
                    setWorkHistoryDataGrid(dataGrid);
                    break;
                case "Заработная плата":
                    setSalaryDataGrid(dataGrid);
                    break;
                case "График работы":
                    setWorkScheduleDataGrid(dataGrid);
                    break;
            }

            DataPanel.Children.Add(dataGrid);
        }

        private void setUserDataGrid(DataGrid dataGrid)
        {
            DataGridTextColumn idColulmn = new DataGridTextColumn();
            DataGridTextColumn loginColumn = new DataGridTextColumn();
            DataGridTextColumn passwordColumn = new DataGridTextColumn();
            DataGridTextColumn employeeColumn = new DataGridTextColumn();

            idColulmn.Header = "ИД";
            loginColumn.Header = "Логин";
            passwordColumn.Header = "Пароль";
            employeeColumn.Header = "ИД Сотрудника";

            idColulmn.Binding = new Binding("id");
            loginColumn.Binding = new Binding("Логин");
            passwordColumn.Binding = new Binding("Пароль");
            employeeColumn.Binding = new Binding("id_сотрудника");

            dataGrid.Columns.Add(idColulmn);
            dataGrid.Columns.Add(loginColumn);
            dataGrid.Columns.Add(passwordColumn);
            dataGrid.Columns.Add(employeeColumn);

            dataGrid.ItemsSource = Database.Instance.Пользователи.ToList();
        }

        private void setEmployeeDataGrid(DataGrid dataGrid)
        {
            DataGridTextColumn idColumn = new DataGridTextColumn();
            DataGridTextColumn lastNameColumn = new DataGridTextColumn();
            DataGridTextColumn firstNameColumn = new DataGridTextColumn();
            DataGridTextColumn middleNameColumn = new DataGridTextColumn();
            DataGridTextColumn birthDateColumn = new DataGridTextColumn();
            DataGridTextColumn genderColumn = new DataGridTextColumn();

            idColumn.Header = "ИД";
            lastNameColumn.Header = "Фамилия";
            firstNameColumn.Header = "Имя";
            middleNameColumn.Header = "Отчество";
            birthDateColumn.Header = "Дата рождения";
            genderColumn.Header = "Пол";

            idColumn.Binding = new Binding("id");
            lastNameColumn.Binding = new Binding("Фамилия");
            firstNameColumn.Binding = new Binding("Имя");
            middleNameColumn.Binding = new Binding("Отчество");
            birthDateColumn.Binding = new Binding("Дата_рождения");
            genderColumn.Binding = new Binding("Пол");

            dataGrid.Columns.Add(idColumn);
            dataGrid.Columns.Add(lastNameColumn);
            dataGrid.Columns.Add(firstNameColumn);
            dataGrid.Columns.Add(middleNameColumn);
            dataGrid.Columns.Add(birthDateColumn);
            dataGrid.Columns.Add(genderColumn);

            dataGrid.ItemsSource = Database.Instance.Сотрудники.ToList();
        }

        private void setPositionDataGrid(DataGrid dataGrid)
        {
            DataGridTextColumn idColumn = new DataGridTextColumn();
            DataGridTextColumn nameColumn = new DataGridTextColumn();
            DataGridTextColumn descriptionColumn = new DataGridTextColumn();

            idColumn.Header = "ИД";
            nameColumn.Header = "Название должности";
            descriptionColumn.Header = "Описание";

            idColumn.Binding = new Binding("id");
            nameColumn.Binding = new Binding("Название_должности");
            descriptionColumn.Binding = new Binding("Описание");

            dataGrid.Columns.Add(idColumn);
            dataGrid.Columns.Add(nameColumn);
            dataGrid.Columns.Add(descriptionColumn);

            dataGrid.ItemsSource = Database.Instance.Должности.ToList();
        }

        private void setDepartmentDataGrid(DataGrid dataGrid)
        {
            DataGridTextColumn idColumn = new DataGridTextColumn();
            DataGridTextColumn nameColumn = new DataGridTextColumn();
            DataGridTextColumn descriptionColumn = new DataGridTextColumn();

            idColumn.Header = "ИД";
            nameColumn.Header = "Название отдела";
            descriptionColumn.Header = "Описание";

            idColumn.Binding = new Binding("id");
            nameColumn.Binding = new Binding("Название_отдела");
            descriptionColumn.Binding = new Binding("Описание");

            dataGrid.Columns.Add(idColumn);
            dataGrid.Columns.Add(nameColumn);
            dataGrid.Columns.Add(descriptionColumn);

            dataGrid.ItemsSource = Database.Instance.Отделы.ToList();
        }

        private void setSkillDataGrid(DataGrid dataGrid)
        {
            DataGridTextColumn idColumn = new DataGridTextColumn();
            DataGridTextColumn nameColumn = new DataGridTextColumn();

            idColumn.Header = "ИД";
            nameColumn.Header = "Название навыка";

            idColumn.Binding = new Binding("id");
            nameColumn.Binding = new Binding("Название_навыка");

            dataGrid.Columns.Add(idColumn);
            dataGrid.Columns.Add(nameColumn);

            dataGrid.ItemsSource = Database.Instance.Навыки.ToList();
        }

        private void setCertificateDataGrid(DataGrid dataGrid)
        {
            DataGridTextColumn idColumn = new DataGridTextColumn();
            DataGridTextColumn nameColumn = new DataGridTextColumn();

            idColumn.Header = "ИД";
            nameColumn.Header = "Название сертификата";

            idColumn.Binding = new Binding("id");
            nameColumn.Binding = new Binding("Название_сертификата");

            dataGrid.Columns.Add(idColumn);
            dataGrid.Columns.Add(nameColumn);

            dataGrid.ItemsSource = Database.Instance.Сертификаты.ToList();
        }

        private void setEducationDataGrid(DataGrid dataGrid)
        {
            DataGridTextColumn idColumn = new DataGridTextColumn();
            DataGridTextColumn institutionColumn = new DataGridTextColumn();
            DataGridTextColumn specialtyColumn = new DataGridTextColumn();
            DataGridTextColumn endDateColumn = new DataGridTextColumn();
            DataGridTextColumn qualificationColumn = new DataGridTextColumn();

            idColumn.Header = "ИД";
            institutionColumn.Header = "Учебное заведение";
            specialtyColumn.Header = "Специальность";
            endDateColumn.Header = "Дата окончания";
            qualificationColumn.Header = "Квалификация";

            idColumn.Binding = new Binding("id");
            institutionColumn.Binding = new Binding("Учебное_заведение");
            specialtyColumn.Binding = new Binding("Специальность");
            endDateColumn.Binding = new Binding("Дата_окончания");
            qualificationColumn.Binding = new Binding("Квалификация");

            dataGrid.Columns.Add(idColumn);
            dataGrid.Columns.Add(institutionColumn);
            dataGrid.Columns.Add(specialtyColumn);
            dataGrid.Columns.Add(endDateColumn);
            dataGrid.Columns.Add(qualificationColumn);

            dataGrid.ItemsSource = Database.Instance.Образование.ToList();
        }

        private void setContactDataGrid(DataGrid dataGrid)
        {
            DataGridTextColumn idColumn = new DataGridTextColumn();
            DataGridTextColumn phoneColumn = new DataGridTextColumn();
            DataGridTextColumn emailColumn = new DataGridTextColumn();
            DataGridTextColumn employeeIdColumn = new DataGridTextColumn();

            idColumn.Header = "ИД";
            phoneColumn.Header = "Телефон";
            emailColumn.Header = "Email";
            employeeIdColumn.Header = "ИД Сотрудника";

            idColumn.Binding = new Binding("id");
            phoneColumn.Binding = new Binding("Телефон");
            emailColumn.Binding = new Binding("Email");
            employeeIdColumn.Binding = new Binding("id_сотрудника");

            dataGrid.Columns.Add(idColumn);
            dataGrid.Columns.Add(phoneColumn);
            dataGrid.Columns.Add(emailColumn);
            dataGrid.Columns.Add(employeeIdColumn);

            dataGrid.ItemsSource = Database.Instance.Контакты.ToList();
        }

        private void setWorkHistoryDataGrid(DataGrid dataGrid)
        {
            DataGridTextColumn idColumn = new DataGridTextColumn();
            DataGridTextColumn employeeIdColumn = new DataGridTextColumn();
            DataGridTextColumn positionIdColumn = new DataGridTextColumn();
            DataGridTextColumn departmentIdColumn = new DataGridTextColumn();
            DataGridTextColumn startDateColumn = new DataGridTextColumn();
            DataGridTextColumn endDateColumn = new DataGridTextColumn();

            idColumn.Header = "ИД";
            employeeIdColumn.Header = "ИД Сотрудника";
            positionIdColumn.Header = "ИД Должности";
            departmentIdColumn.Header = "ИД Отдела";
            startDateColumn.Header = "Дата начала";
            endDateColumn.Header = "Дата окончания";

            idColumn.Binding = new Binding("id");
            employeeIdColumn.Binding = new Binding("id_сотрудника");
            positionIdColumn.Binding = new Binding("id_должности");
            departmentIdColumn.Binding = new Binding("id_отдела");
            startDateColumn.Binding = new Binding("Дата_начала");
            endDateColumn.Binding = new Binding("Дата_окончания");

            dataGrid.Columns.Add(idColumn);
            dataGrid.Columns.Add(employeeIdColumn);
            dataGrid.Columns.Add(positionIdColumn);
            dataGrid.Columns.Add(departmentIdColumn);
            dataGrid.Columns.Add(startDateColumn);
            dataGrid.Columns.Add(endDateColumn);

            dataGrid.ItemsSource = Database.Instance.История_работы.ToList();
        }

        private void setSalaryDataGrid(DataGrid dataGrid)
        {
            DataGridTextColumn idColumn = new DataGridTextColumn();
            DataGridTextColumn employeeIdColumn = new DataGridTextColumn();
            DataGridTextColumn paymentDateColumn = new DataGridTextColumn();
            DataGridTextColumn amountColumn = new DataGridTextColumn();

            idColumn.Header = "ИД";
            employeeIdColumn.Header = "ИД Сотрудника";
            paymentDateColumn.Header = "Дата выплаты";
            amountColumn.Header = "Сумма";

            idColumn.Binding = new Binding("id");
            employeeIdColumn.Binding = new Binding("id_сотрудника");
            paymentDateColumn.Binding = new Binding("Дата_выплаты");
            amountColumn.Binding = new Binding("Сумма");

            dataGrid.Columns.Add(idColumn);
            dataGrid.Columns.Add(employeeIdColumn);
            dataGrid.Columns.Add(paymentDateColumn);
            dataGrid.Columns.Add(amountColumn);

            dataGrid.ItemsSource = Database.Instance.Заработная_плата.ToList();
        }

        private void setWorkScheduleDataGrid(DataGrid dataGrid)
        {
            DataGridTextColumn idColumn = new DataGridTextColumn();
            DataGridTextColumn employeeIdColumn = new DataGridTextColumn();
            DataGridTextColumn scheduleTypeColumn = new DataGridTextColumn();
            DataGridTextColumn notesColumn = new DataGridTextColumn();

            idColumn.Header = "ИД";
            employeeIdColumn.Header = "ИД Сотрудника";
            scheduleTypeColumn.Header = "Тип графика";
            notesColumn.Header = "Примечание";

            idColumn.Binding = new Binding("id");
            employeeIdColumn.Binding = new Binding("id_сотрудника");
            scheduleTypeColumn.Binding = new Binding("Тип_графика");
            notesColumn.Binding = new Binding("Примечание");

            dataGrid.Columns.Add(idColumn);
            dataGrid.Columns.Add(employeeIdColumn);
            dataGrid.Columns.Add(scheduleTypeColumn);
            dataGrid.Columns.Add(notesColumn);

            dataGrid.ItemsSource = Database.Instance.График_работы.ToList();
        }

        public static DataGrid getNewDataGrid()
        {
            DataGrid dataGrid = new DataGrid();
            dataGrid.AutoGenerateColumns = false;
            dataGrid.IsReadOnly = true;
            dataGrid.Width = 600;
            dataGrid.Height = 225;

            return dataGrid;
        }

        public static Boolean isSelectedEntity()
        {
            if (dataGrid.SelectedItem == null)
            {
                MessageBox.Show("Запись не выбрана!\nВыберите её.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
    }
}
