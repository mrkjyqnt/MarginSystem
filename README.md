# Margin’s Desktop Inventory and Sales Management System with Barcode Scanning

A thesis project developed by BSIT students from Datamex College of Saint Adeline, designed to optimize inventory and sales processes for small retail businesses using a user-friendly Windows desktop application.

---

## 📌 Project Overview

**Margin’s Inventory and Sales Management System** is a desktop-based software solution developed to address the challenges of manual inventory tracking and sales management faced by small businesses, particularly **Margin’s Store** (a wholesaler grocery). The system is equipped with **barcode scanning**, real-time inventory monitoring, expense tracking, and automated report generation.

---

## 👥 Project Members

- John Francis T. Canlas  
- Ray Jay R. Dangculos  
- Kyle T. Deudor  
- Leojay F. Fedelin  
- Dimple L. Marin  
- Prince Lorevic A. Roxas  
- Kim Justine R. Sabando  
- Mark Jay S. Quinto  

---

## 🎯 Objectives

### Primary Objectives:
- Create a desktop-based inventory and sales management system.
- Integrate barcode scanning for faster and more accurate operations.
- Automate inventory, sales, and expense tracking.
- Generate financial and inventory reports.

### Secondary Objectives:
- Reduce transaction time and manual workload.
- Enable better product availability and decision-making.
- Provide future scalability and insights through analytics.

---

## 🧩 Features

- **Dashboard**: Real-time KPIs on inventory and sales.
- **Product Management**: Add, update, and track products via barcode.
- **Stock Management**: Manage batches, restocks, and stock transactions.
- **Inventory Monitoring**: Track transactions, expirations, and availability.
- **Sales Module**: Process sales using barcode scanning.
- **Reports and Valuation**: Detailed insights into inventory value and revenue.
- **Data Backup & Recovery**: Local & Google Drive integration for secure backups.
- **User Accounts**: Profile management, PIN security, and logout.

---

## 🛠 Technologies Used

| Technology | Purpose |
|------------|---------|
| Visual Basic .NET | Primary programming language |
| SQL Server | Backend database management |
| .NET Framework | Desktop application runtime |
| Guna UI2 | Enhanced WinForms UI |
| Adobe XD / Figma | UI prototyping |
| Google Drive API | Cloud-based backup |
| Brevo API | Transactional email alerts |

---

## 🏗 System Architecture

- **Presentation Layer**: WinForms UI + Guna UI2
- **Business Logic Layer**: Inventory, Sales, Reporting, Backup modules
- **Data Layer**: SQL Server Database

---

## 💾 Installation & Configuration

### Minimum Requirements:
- OS: Windows 10+
- RAM: 8 GB
- Storage: 1 GB+
- Barcode Scanner (USB)

### Steps:
1. Run the installer.
2. Choose installation location and optional desktop shortcut.
3. Launch the application as Administrator.
4. Configure database and backup settings if necessary.

### Additional Developer Setup:
Incase of pull from repository, make sure to replace the following:

1. Create a user secret
2. Place the path to: CapstoneSystem\Modules\DataBackupModule.vb:246
3. Replace the Credential's Username and Password for Brevo Accounts:
  - CapstoneSystem\Forms\Data Backup and Recovery\RestoreBackup.vb:138
  - CapstoneSystem\Forms\Data Backup and Recovery\DeleteBackup.vb:144
  - CapstoneSystem\Forms\Account\ModifyPin.vb:18


For additional installation information, see the full [User Guide](#) and [Technical Documentation](#) for detailed instructions.

---

## 🧪 Testing & Validation

- **Unit Testing**: Component-level tests (e.g. barcode scanning, sales tracking).
- **Integration Testing**: Google API, Crystal Reports, UI interactions.
- **System Testing**: Stress tests, power-loss simulations, security scenarios.
- **User Acceptance Testing (UAT)**: Based on ISO 9126 standards.

---

## 🚀 Deployment

- Standalone deployment on local Windows machines.
- Includes optional integration with Google Drive.
- All dependencies (e.g., .NET Desktop Runtime, SQL Express) must be installed beforehand.

---

## 🔧 Maintenance

- **Daily**: Auto backup, log checks.
- **Weekly**: Security patches, disk clean-up.
- **Monthly**: Software and API updates.
- **Yearly**: Hardware and scalability evaluations.

---

## 🔐 Security Features

- PIN-protected backups and restoration.
- System lock after 5 failed login attempts.
- Activity logging per user account.

---

## 📈 Future Improvements

- Web-based version using ASP.NET Core.
- Mobile app companion for inventory tracking.
- AI-driven analytics for sales forecasting.
- Two-factor authentication.

---

## 📄 License

This project is for academic purposes under the guidance of **Datamex College of Saint Adeline**. Commercial use requires prior authorization from the authors.

---

## 📬 Contact

For inquiries, reach out to:

**Project Leader:**  
Dimple L. Marin  
📧 dimple.marin.016@gmail.com

**Lead Developer:**  
Ray Jay Dangculos
[LinkedIn](https://linkedin.com/in/ray-jay-dangculos-02b18b341)
---

