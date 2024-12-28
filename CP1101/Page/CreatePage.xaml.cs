using CP1101.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CP1101.Pages
{
    public partial class CreatePage : Page
    {
        private string tableName;

        // Переменные для хранения ссылок на редактируемые поля
        private TextBox loginTxt;
        private TextBox passwordTxt;
        private ComboBox employeeCbx;

        private TextBox surnameTxt;
        private TextBox nameTxt;
        private TextBox patronymicTxt;
        private DatePicker birthDateTxt;
        private ComboBox genderCbx;

        private TextBox positionNameTxt;
        private TextBox positionDescriptionTxt;

        private TextBox departmentNameTxt;
        private TextBox departmentDescriptionTxt;

        private TextBox skillNameTxt;

        private TextBox certificateNameTxt;

        private TextBox institutionTxt;
        private TextBox specialtyTxt;
        private DatePicker endDateTxt;
        private TextBox qualificationTxt;

        private TextBox phoneTxt;
        private TextBox emailTxt;

        private ComboBox workHistoryEmployeeCbx;
        private ComboBox workHistoryPositionCbx;
        private ComboBox workHistoryDepartmentCbx;
        private DatePicker workHistoryStartDateTxt;
        private DatePicker workHistoryEndDateTxt;

        private DatePicker paymentDateTxt;
        private TextBox amountTxt;

        private TextBox workScheduleTypeTxt;
        private TextBox workScheduleNotesTxt;

        public CreatePage(string tableName)
        {
            InitializeComponent();
            this.tableName = tableName;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            EntityFieldsPanel.Children.Clear();

            switch (this.tableName)
            {
                case "Пользователи":
                    setUserField();
                    break;
                case "Сотрудники":
                    setEmployeeField();
                    break;
                case "Должности":
                    setPositionField();
                    break;
                case "Отделы":
                    setDepartmentField();
                    break;
                case "Навыки":
                    setSkillField();
                    break;
                case "Сертификаты":
                    setCertificateField();
                    break;
                case "Образование":
                    setEducationField();
                    break;
                case "Контакты":
                    setContactField();
                    break;
                case "История работы":
                    setWorkHistoryField();
                    break;
                case "Заработная плата":
                    setSalaryField();
                    break;
                case "График работы":
                    setWorkScheduleField();
                    break;
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            switch (tableName)
            {
                case "Пользователи":
                    createUser();
                    break;
                case "Сотрудники":
                    createEmployee();
                    break;
                case "Должности":
                    createPosition();
                    break;
                case "Отделы":
                    createDepartment();
                    break;
                case "Навыки":
                    createSkill();
                    break;
                case "Сертификаты":
                    createCertificate();
                    break;
                case "Образование":
                    createEducation();
                    break;
                case "Контакты":
                    createContact();
                    break;
                case "История работы":
                    createWorkHistory();
                    break;
                case "Заработная плата":
                    createSalary();
                    break;
                case "График работы":
                    createWorkSchedule();
                    break;
            }

            Database.save();
            Navigation.CurrentFrame.Navigate(new MainPage(tableName));
        }

        private void setUserField()
        {
            // Создаем UI элементы для ввода нового пользователя
            Label loginLbl = new Label() { Content = "Логин", Width = 150 };
            Label passwordLbl = new Label() { Content = "Пароль", Width = 150 };
            Label employeeLbl = new Label() { Content = "ИД Сотрудника", Width = 150 };

            loginTxt = new TextBox() { Width = 150 };
            passwordTxt = new TextBox() { Width = 150 };
            employeeCbx = new ComboBox()
            {
                ItemsSource = Database.Instance.Сотрудники.ToList(),
                DisplayMemberPath = "id",
                Width = 150
            };

            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(loginLbl, loginTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(passwordLbl, passwordTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(employeeLbl, employeeCbx));
        }

        private void setEmployeeField()
        {
            // Создаем UI элементы для ввода нового сотрудника
            Label surnameLbl = new Label() { Content = "Фамилия", Width = 150 };
            Label nameLbl = new Label() { Content = "Имя", Width = 150 };
            Label patronymicLbl = new Label() { Content = "Отчество", Width = 150 };
            Label birthDateLbl = new Label() { Content = "Дата рождения", Width = 150 };
            Label genderLbl = new Label() { Content = "Пол", Width = 150 };

            surnameTxt = new TextBox() { Width = 150 };
            nameTxt = new TextBox() { Width = 150 };
            patronymicTxt = new TextBox() { Width = 150 };
            birthDateTxt = new DatePicker() { Width = 150 }; // Можно использовать DatePicker для выбора даты
            genderCbx = new ComboBox()
            {
                ItemsSource = new List<string> { "М", "Ж" },
                Width = 150
            };

            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(surnameLbl, surnameTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(nameLbl, nameTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(patronymicLbl, patronymicTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(birthDateLbl, birthDateTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(genderLbl, genderCbx));
        }

        private void setPositionField()
        {
            // Создаем UI элементы для ввода новой должности
            Label nameLbl = new Label() { Content = "Название должности", Width = 150 };
            Label descriptionLbl = new Label() { Content = "Описание", Width = 150 };

            positionNameTxt = new TextBox() { Width = 150 };
            positionDescriptionTxt = new TextBox() { Width = 150 };

            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(nameLbl, positionNameTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(descriptionLbl, positionDescriptionTxt));
        }

        private void setDepartmentField()
        {
            // Создаем UI элементы для ввода нового отдела
            Label nameLbl = new Label() { Content = "Название отдела", Width = 150 };
            Label descriptionLbl = new Label() { Content = "Описание", Width = 150 };

            departmentNameTxt = new TextBox() { Width = 150 };
            departmentDescriptionTxt = new TextBox() { Width = 150 };

            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(nameLbl, departmentNameTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(descriptionLbl, departmentDescriptionTxt));
        }

        private void setSkillField()
        {
            // Создаем UI элементы для ввода нового навыка
            Label nameLbl = new Label() { Content = "Название навыка", Width = 150 };

            skillNameTxt = new TextBox() { Width = 150 };

            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(nameLbl, skillNameTxt));
        }

        private void setCertificateField()
        {
            // Создаем UI элементы для ввода нового сертификата
            Label nameLbl = new Label() { Content = "Название сертификата", Width = 150 };

            certificateNameTxt = new TextBox() { Width = 150 };

            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(nameLbl, certificateNameTxt));
        }

        private void setEducationField()
        {
            // Создаем UI элементы для ввода нового образования
            Label institutionLbl = new Label() { Content = "Учебное заведение", Width = 150 };
            Label specialtyLbl = new Label() { Content = "Специальность", Width = 150 };
            Label endDateLbl = new Label() { Content = "Дата окончания", Width = 150 };
            Label qualificationLbl = new Label() { Content = "Квалификация", Width = 150 };

            institutionTxt = new TextBox() { Width = 150 };
            specialtyTxt = new TextBox() { Width = 150 };
            endDateTxt = new DatePicker() { Width = 150 };
            qualificationTxt = new TextBox() { Width = 150 };

            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(institutionLbl, institutionTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(specialtyLbl, specialtyTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(endDateLbl, endDateTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(qualificationLbl, qualificationTxt));
        }

        private void setContactField()
        {
            // Создаем UI элементы для ввода нового контакта
            Label phoneLbl = new Label() { Content = "Телефон", Width = 150 };
            Label emailLbl = new Label() { Content = "Email", Width = 150 };

            phoneTxt = new TextBox() { Width = 150 };
            emailTxt = new TextBox() { Width = 150 };

            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(phoneLbl, phoneTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(emailLbl, emailTxt));
        }

        private void setWorkHistoryField()
        {
            // Создаем UI элементы для ввода новой записи в историю работы
            Label employeeLbl = new Label() { Content = "ИД Сотрудника", Width = 150 };
            Label positionLbl = new Label() { Content = "ИД Должности", Width = 150 };
            Label departmentLbl = new Label() { Content = "ИД Отдела", Width = 150 };
            Label startDateLbl = new Label() { Content = "Дата начала", Width = 150 };
            Label endDateLbl = new Label() { Content = "Дата окончания", Width = 150 };

            workHistoryEmployeeCbx = new ComboBox()
            {
                ItemsSource = Database.Instance.Сотрудники.ToList(),
                DisplayMemberPath = "id",
                Width = 150
            };

            workHistoryPositionCbx = new ComboBox()
            {
                ItemsSource = Database.Instance.Должности.ToList(),
                DisplayMemberPath = "id",
                Width = 150
            };

            workHistoryDepartmentCbx = new ComboBox()
            {
                ItemsSource = Database.Instance.Отделы.ToList(),
                DisplayMemberPath = "id",
                Width = 150
            };

            workHistoryStartDateTxt = new DatePicker() { Width = 150 };
            workHistoryEndDateTxt = new DatePicker() { Width = 150 };

            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(employeeLbl, workHistoryEmployeeCbx));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(positionLbl, workHistoryPositionCbx));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(departmentLbl, workHistoryDepartmentCbx));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(startDateLbl, workHistoryStartDateTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(endDateLbl, workHistoryEndDateTxt));
        }

        private void setSalaryField()
        {
            // Создаем UI элементы для ввода новой зарплаты
            Label paymentDateLbl = new Label() { Content = "Дата выплаты", Width = 150 };
            Label amountLbl = new Label() { Content = "Сумма", Width = 150 };

            paymentDateTxt = new DatePicker() { Width = 150 };
            amountTxt = new TextBox() { Width = 150 };

            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(paymentDateLbl, paymentDateTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(amountLbl, amountTxt));
        }

        private void setWorkScheduleField()
        {
            // Создаем UI элементы для ввода нового графика работы
            Label scheduleTypeLbl = new Label() { Content = "Тип графика", Width = 150 };
            Label notesLbl = new Label() { Content = "Примечание", Width = 150 };

            workScheduleTypeTxt = new TextBox() { Width = 150 };
            workScheduleNotesTxt = new TextBox() { Width = 150 };

            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(scheduleTypeLbl, workScheduleTypeTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(notesLbl, workScheduleNotesTxt));
        }

        private void createUser()
        {
            Пользователи newUser = new Пользователи
            {
                Логин = loginTxt.Text,
                Пароль = passwordTxt.Text,
                id_сотрудника = (employeeCbx.SelectedItem as Сотрудники)?.id
            };
            Database.Instance.Пользователи.Add(newUser);
        }

        private void createEmployee()
        {
            Сотрудники newEmployee = new Сотрудники
            {
                Фамилия = surnameTxt.Text,
                Имя = nameTxt.Text,
                Отчество = patronymicTxt.Text,
                Дата_рождения = DateTime.Parse(birthDateTxt.Text),
                Пол = genderCbx.SelectedItem.ToString()
            };
            Database.Instance.Сотрудники.Add(newEmployee);
        }

        private void createPosition()
        {
            Должности newPosition = new Должности
            {
                Название_должности = positionNameTxt.Text,
                Описание = positionDescriptionTxt.Text
            };
            Database.Instance.Должности.Add(newPosition);
        }

        private void createDepartment()
        {
            Отделы newDepartment = new Отделы
            {
                Название_отдела = departmentNameTxt.Text,
                Описание = departmentDescriptionTxt.Text
            };
            Database.Instance.Отделы.Add(newDepartment);
        }

        private void createSkill()
        {
            Навыки newSkill = new Навыки
            {
                Название_навыка = skillNameTxt.Text
            };
            Database.Instance.Навыки.Add(newSkill);
        }

        private void createCertificate()
        {
            Сертификаты newCertificate = new Сертификаты
            {
                Название_сертификата = certificateNameTxt.Text
            };
            Database.Instance.Сертификаты.Add(newCertificate);
        }

        private void createEducation()
        {
            Образование newEducation = new Образование
            {
                Учебное_заведение = institutionTxt.Text,
                Специальность = specialtyTxt.Text,
                Дата_окончания = DateTime.Parse(endDateTxt.Text),
                Квалификация = qualificationTxt.Text
            };
            Database.Instance.Образование.Add(newEducation);
        }

        private void createContact()
        {
            Контакты newContact = new Контакты
            {
                Телефон = phoneTxt.Text,
                Email = emailTxt.Text
            };
            Database.Instance.Контакты.Add(newContact);
        }

        private void createWorkHistory()
        {
            История_работы newWorkHistory = new История_работы
            {
                id_сотрудника = (workHistoryEmployeeCbx.SelectedItem as Сотрудники).id,
                id_должности = (workHistoryPositionCbx.SelectedItem as Должности).id,
                id_отдела = (workHistoryDepartmentCbx.SelectedItem as Отделы).id,
                Дата_начала = DateTime.Parse(workHistoryStartDateTxt.Text),
                Дата_окончания = DateTime.Parse(workHistoryEndDateTxt.Text)
            };
            Database.Instance.История_работы.Add(newWorkHistory);
        }

        private void createSalary()
        {
            Заработная_плата newSalary = new Заработная_плата
            {
                Дата_выплаты = DateTime.Parse(paymentDateTxt.Text),
                Сумма = decimal.Parse(amountTxt.Text)
            };
            Database.Instance.Заработная_плата.Add(newSalary);
        }

        private void createWorkSchedule()
        {
            График_работы newWorkSchedule = new График_работы
            {
                Тип_графика = workScheduleTypeTxt.Text,
                Примечание = workScheduleNotesTxt.Text
            };
            Database.Instance.График_работы.Add(newWorkSchedule);
        }


        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Navigation.CurrentFrame.Navigate(new MainPage(tableName));
        }
    }
}
