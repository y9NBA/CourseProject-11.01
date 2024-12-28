using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CP1101.Util;

namespace CP1101.Pages
{
    public partial class EditPage : Page
    {
        private Object entity;
        private string tableName;

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
        private TextBox endDateTxt;
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

        public EditPage(string tableName, Object o)
        {
            InitializeComponent();
            this.tableName = tableName;
            this.entity = o;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            EntityFieldsPanel.Children.Clear();

            switch (this.tableName)
            {
                case "Пользователи":
                    setUserData();
                    break;
                case "Сотрудники":
                    setEmployeeData();
                    break;
                case "Должности":
                    setPositionData();
                    break;
                case "Отделы":
                    setDepartmentData();
                    break;
                case "Навыки":
                    setSkillData();
                    break;
                case "Сертификаты":
                    setCertificateData();
                    break;
                case "Образование":
                    setEducationData();
                    break;
                case "Контакты":
                    setContactData();
                    break;
                case "История работы":
                    setWorkHistoryData();
                    break;
                case "Заработная плата":
                    setSalaryData();
                    break;
                case "График работы":
                    setWorkScheduleData();
                    break;
            }
        }

        private void setUserData()
        {
            Пользователи user = this.entity as Пользователи;

            Label idLbl = new Label() { Content = "ИД", Width = 150 };
            Label loginLbl = new Label() { Content = "Логин", Width = 150 };
            Label passwordLbl = new Label() { Content = "Пароль", Width = 150 };
            Label employeeLbl = new Label() { Content = "ИД Сотрудника", Width = 150 };

            TextBlock idTxt = new TextBlock() { Text = user.id.ToString(), Width = 150 };
            loginTxt = new TextBox() { Text = user.Логин, Width = 150 };
            passwordTxt = new TextBox() { Text = user.Пароль, Width = 150 };
            employeeCbx = new ComboBox()
            {
                ItemsSource = Database.Instance.Сотрудники.ToList(),
                DisplayMemberPath = "id",
                SelectedItem = user.Сотрудники,
                Width = 150
            };

            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(idLbl, idTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(loginLbl, loginTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(passwordLbl, passwordTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(employeeLbl, employeeCbx));
        }

        private void setEmployeeData()
        {
            Сотрудники employee = this.entity as Сотрудники;

            Label idLbl = new Label() { Content = "ИД", Width = 150 };
            Label surnameLbl = new Label() { Content = "Фамилия", Width = 150 };
            Label nameLbl = new Label() { Content = "Имя", Width = 150 };
            Label patronymicLbl = new Label() { Content = "Отчество", Width = 150 };
            Label birthDateLbl = new Label() { Content = "Дата рождения", Width = 150 };
            Label genderLbl = new Label() { Content = "Пол", Width = 150 };

            TextBlock idTxt = new TextBlock() { Text = employee.id.ToString(), Width = 150 };
            surnameTxt = new TextBox() { Text = employee.Фамилия, Width = 150 };
            nameTxt = new TextBox() { Text = employee.Имя, Width = 150 };
            patronymicTxt = new TextBox() { Text = employee.Отчество, Width = 150 };
            birthDateTxt = new DatePicker() { Text = employee.Дата_рождения.ToString(), Width = 150 };
            genderCbx = new ComboBox()
            {
                ItemsSource = new List<string> { "М", "Ж" },
                SelectedItem = employee.Пол,
                Width = 150
            };

            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(idLbl, idTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(surnameLbl, surnameTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(nameLbl, nameTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(patronymicLbl, patronymicTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(birthDateLbl, birthDateTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(genderLbl, genderCbx));
        }

        private void setPositionData()
        {
            Должности position = this.entity as Должности;

            Label idLbl = new Label() { Content = "ИД", Width = 150 };
            Label nameLbl = new Label() { Content = "Название должности", Width = 150 };
            Label descriptionLbl = new Label() { Content = "Описание", Width = 150 };

            TextBlock idTxt = new TextBlock() { Text = position.id.ToString(), Width = 150 };
            positionNameTxt = new TextBox() { Text = position.Название_должности, Width = 150 };
            positionDescriptionTxt = new TextBox() { Text = position.Описание, Width = 150 };

            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(idLbl, idTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(nameLbl, positionNameTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(descriptionLbl, positionDescriptionTxt));
        }

        private void setDepartmentData()
        {
            Отделы department = this.entity as Отделы;

            Label idLbl = new Label() { Content = "ИД", Width = 150 };
            Label nameLbl = new Label() { Content = "Название отдела", Width = 150 };
            Label descriptionLbl = new Label() { Content = "Описание", Width = 150 };

            TextBlock idTxt = new TextBlock() { Text = department.id.ToString(), Width = 150 };
            departmentNameTxt = new TextBox() { Text = department.Название_отдела, Width = 150 };
            departmentDescriptionTxt = new TextBox() { Text = department.Описание, Width = 150 };

            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(idLbl, idTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(nameLbl, departmentNameTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(descriptionLbl, departmentDescriptionTxt));
        }

        private void setSkillData()
        {
            Навыки skill = this.entity as Навыки;

            Label idLbl = new Label() { Content = "ИД", Width = 150 };
            Label nameLbl = new Label() { Content = "Название навыка", Width = 150 };

            TextBlock idTxt = new TextBlock() { Text = skill.id.ToString(), Width = 150 };
            skillNameTxt = new TextBox() { Text = skill.Название_навыка, Width = 150 };

            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(idLbl, idTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(nameLbl, skillNameTxt));
        }

        private void setCertificateData()
        {
            Сертификаты certificate = this.entity as Сертификаты;

            Label idLbl = new Label() { Content = "ИД", Width = 150 };
            Label nameLbl = new Label() { Content = "Название сертификата", Width = 150 };

            TextBlock idTxt = new TextBlock() { Text = certificate.id.ToString(), Width = 150 };
            certificateNameTxt = new TextBox() { Text = certificate.Название_сертификата, Width = 150 };

            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(idLbl, idTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(nameLbl, certificateNameTxt));
        }

        private void setEducationData()
        {
            Образование education = this.entity as Образование;

            Label idLbl = new Label() { Content = "ИД", Width = 150 };
            Label institutionLbl = new Label() { Content = "Учебное заведение", Width = 150 };
            Label specialtyLbl = new Label() { Content = "Специальность", Width = 150 };
            Label endDateLbl = new Label() { Content = "Дата окончания", Width = 150 };
            Label qualificationLbl = new Label() { Content = "Квалификация", Width = 150 };

            TextBlock idTxt = new TextBlock() { Text = education.id.ToString(), Width = 150 };
            institutionTxt = new TextBox() { Text = education.Учебное_заведение, Width = 150 };
            specialtyTxt = new TextBox() { Text = education.Специальность, Width = 150 };
            endDateTxt = new TextBox() { Text = education.Дата_окончания.ToString(), Width = 150 };
            qualificationTxt = new TextBox() { Text = education.Квалификация, Width = 150 };

            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(idLbl, idTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(institutionLbl, institutionTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(specialtyLbl, specialtyTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(endDateLbl, endDateTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(qualificationLbl, qualificationTxt));
        }

        private void setContactData()
        {
            Контакты contact = this.entity as Контакты;

            Label idLbl = new Label() { Content = "ИД", Width = 150 };
            Label phoneLbl = new Label() { Content = "Телефон", Width = 150 };
            Label emailLbl = new Label() { Content = "Email", Width = 150 };

            TextBlock idTxt = new TextBlock() { Text = contact.id.ToString(), Width = 150 };
            phoneTxt = new TextBox() { Text = contact.Телефон, Width = 150 };
            emailTxt = new TextBox() { Text = contact.Email, Width = 150 };

            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(idLbl, idTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(phoneLbl, phoneTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(emailLbl, emailTxt));
        }

        private void setWorkHistoryData()
        {
            История_работы workHistory = this.entity as История_работы;

            Label idLbl = new Label() { Content = "ИД", Width = 150 };
            Label employeeLbl = new Label() { Content = "ИД Сотрудника", Width = 150 };
            Label positionLbl = new Label() { Content = "ИД Должности", Width = 150 };
            Label departmentLbl = new Label() { Content = "ИД Отдела", Width = 150 };
            Label startDateLbl = new Label() { Content = "Дата начала", Width = 150 };
            Label endDateLbl = new Label() { Content = "Дата окончания", Width = 150 };

            TextBlock idTxt = new TextBlock() { Text = workHistory.id.ToString(), Width = 150 };
            workHistoryEmployeeCbx = new ComboBox()
            {
                ItemsSource = Database.Instance.Сотрудники.ToList(),
                DisplayMemberPath = "id",
                SelectedItem = workHistory.Сотрудники,
                Width = 150
            };

            workHistoryPositionCbx = new ComboBox()
            {
                ItemsSource = Database.Instance.Должности.ToList(),
                DisplayMemberPath = "id",
                SelectedItem = workHistory.Должности,
                Width = 150
            };

            workHistoryDepartmentCbx = new ComboBox()
            {
                ItemsSource = Database.Instance.Отделы.ToList(),
                DisplayMemberPath = "id",
                SelectedItem = workHistory.Отделы,
                Width = 150
            };

            workHistoryStartDateTxt = new DatePicker() { Text = workHistory.Дата_начала.ToString(), Width = 150 };
            workHistoryEndDateTxt = new DatePicker() { Text = workHistory.Дата_окончания?.ToShortDateString(), Width = 150 };

            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(idLbl, idTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(employeeLbl, workHistoryEmployeeCbx));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(positionLbl, workHistoryPositionCbx));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(departmentLbl, workHistoryDepartmentCbx));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(startDateLbl, workHistoryStartDateTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(endDateLbl, workHistoryEndDateTxt));
        }

        private void setSalaryData()
        {
            Заработная_плата salary = this.entity as Заработная_плата;

            Label idLbl = new Label() { Content = "ИД", Width = 150 };
            Label paymentDateLbl = new Label() { Content = "Дата выплаты", Width = 150 };
            Label amountLbl = new Label() { Content = "Сумма", Width = 150 };

            TextBlock idTxt = new TextBlock() { Text = salary.id.ToString(), Width = 150 };
            paymentDateTxt = new DatePicker() { Text = salary.Дата_выплаты.ToShortDateString(), Width = 150 };
            amountTxt = new TextBox() { Text = salary.Сумма.ToString(), Width = 150 };

            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(idLbl, idTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(paymentDateLbl, paymentDateTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(amountLbl, amountTxt));
        }

        private void setWorkScheduleData()
        {
            График_работы workSchedule = this.entity as График_работы;

            Label idLbl = new Label() { Content = "ИД", Width = 150 };
            Label scheduleTypeLbl = new Label() { Content = "Тип графика", Width = 150 };
            Label notesLbl = new Label() { Content = "Примечание", Width = 150 };

            TextBlock idTxt = new TextBlock() { Text = workSchedule.id.ToString(), Width = 150 };
            workScheduleTypeTxt = new TextBox() { Text = workSchedule.Тип_графика, Width = 150 };
            workScheduleNotesTxt = new TextBox() { Text = workSchedule.Примечание, Width = 150 };

            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(idLbl, idTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(scheduleTypeLbl, workScheduleTypeTxt));
            EntityFieldsPanel.Children.Add(UIUtil.concatDuoElements(notesLbl, workScheduleNotesTxt));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Navigation.CurrentFrame.GoBack();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            switch (tableName)
            {
                case "Пользователи":
                    updateUser();
                    break;
                case "Сотрудники":
                    updateEmployee();
                    break;
                case "Должности":
                    updatePosition();
                    break;
                case "Отделы":
                    updateDepartment();
                    break;
                case "Навыки":
                    updateSkill();
                    break;
                case "Сертификаты":
                    updateCertificate();
                    break;
                case "Образование":
                    updateEducation();
                    break;
                case "Контакты":
                    updateContact();
                    break;
                case "История работы":
                    updateWorkHistory();
                    break;
                case "Заработная плата":
                    updateSalary();
                    break;
                case "График работы":
                    updateWorkSchedule();
                    break;
            }

            Database.save();
            Navigation.CurrentFrame.Navigate(new MainPage(tableName));
        }

        private void updateUser()
        {
            Пользователи user = this.entity as Пользователи;
            user.Логин = loginTxt.Text;
            user.Пароль = passwordTxt.Text;
            user.id_сотрудника = (employeeCbx.SelectedItem as Сотрудники)?.id;
        }

        private void updateEmployee()
        {
            Сотрудники employee = this.entity as Сотрудники;
            employee.Фамилия = surnameTxt.Text;
            employee.Имя = nameTxt.Text;
            employee.Отчество = patronymicTxt.Text;
            employee.Дата_рождения = DateTime.Parse(birthDateTxt.Text);
            employee.Пол = genderCbx.SelectedItem.ToString();
        }

        private void updatePosition()
        {
            Должности position = this.entity as Должности;
            position.Название_должности = positionNameTxt.Text;
            position.Описание = positionDescriptionTxt.Text;
        }

        private void updateDepartment()
        {
            Отделы department = this.entity as Отделы;
            department.Название_отдела = departmentNameTxt.Text;
            department.Описание = departmentDescriptionTxt.Text;
        }

        private void updateSkill()
        {
            Навыки skill = this.entity as Навыки;
            skill.Название_навыка = skillNameTxt.Text;
        }

        private void updateCertificate()
        {
            Сертификаты certificate = this.entity as Сертификаты;
            certificate.Название_сертификата = certificateNameTxt.Text;
        }

        private void updateEducation()
        {
            Образование education = this.entity as Образование;
            education.Учебное_заведение = institutionTxt.Text;
            education.Специальность = specialtyTxt.Text;
            education.Дата_окончания = DateTime.Parse(endDateTxt.Text);
            education.Квалификация = qualificationTxt.Text;
        }

        private void updateContact()
        {
            Контакты contact = this.entity as Контакты;
            contact.Телефон = phoneTxt.Text;
            contact.Email = emailTxt.Text;
        }

        private void updateWorkHistory()
        {
            История_работы workHistory = this.entity as История_работы;
            workHistory.id_сотрудника = (workHistoryEmployeeCbx.SelectedItem as Сотрудники).id;
            workHistory.id_должности = (workHistoryPositionCbx.SelectedItem as Должности).id;
            workHistory.id_отдела = (workHistoryDepartmentCbx.SelectedItem as Отделы).id;
            workHistory.Дата_начала = DateTime.Parse(workHistoryStartDateTxt.Text);
            workHistory.Дата_окончания = DateTime.Parse(workHistoryEndDateTxt.Text);
        }

        private void updateSalary()
        {
            Заработная_плата salary = this.entity as Заработная_плата;
            salary.Дата_выплаты = DateTime.Parse(paymentDateTxt.Text);
            salary.Сумма = decimal.Parse(amountTxt.Text);
        }

        private void updateWorkSchedule()
        {
            График_работы workSchedule = this.entity as График_работы;
            workSchedule.Тип_графика = workScheduleTypeTxt.Text;
            workSchedule.Примечание = workScheduleNotesTxt.Text;
        }
    }
}
