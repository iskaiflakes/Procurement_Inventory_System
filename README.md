# Procurement_Inventory_System

## Overview

**Procurement_Inventory_System** is a software application designed to manage procurement and inventory processes for organizations. It streamlines tasks such as purchase ordering, invoice management, supplier quotations, inventory tracking, and reporting—helping organizations to efficiently handle supply chain and asset management operations.

## Features

- **Purchase Order Management:** Create, approve, and track purchase orders.
- **Supplier Quotation Handling:** Manage and review supplier quotations.
- **Invoice Management:** Generate and manage invoices for purchases.
- **Inventory Tracking:** Monitor inventory levels and manage supply requests.
- **User Management:** Role-based user interfaces for different actors (Admin, Approver, Custodian, President, Requestor, Supplier, etc.).
- **Reporting:** Generate various reports for procurement and inventory activities.
- **Audit Logs:** Keep track of user actions and system changes for traceability.

## Getting Started

### Prerequisites

- **.NET Framework** (likely 4.7.2 or compatible, as indicated by typical WinForms directory structure)
- **Windows OS** (the system is designed for Windows, using WinForms)
- **Database** (e.g., SQL Server; database connection and setup are required)
- **Required Dependencies** (found in `bin/Debug` or referenced in project files):
  - `BouncyCastle.Cryptography`
  - `MailKit`
  - `MimeKit`
  - `Microsoft.ReportViewer.WinForms`
  - `System.Buffers`
  - `System.Formats.Asn1`
  - `System.Memory`
  - `System.Numerics.Vectors`
  - `System.Runtime.CompilerServices.Unsafe`
  - `System.Threading.Tasks.Extensions`
  - `System.ValueTuple`

_Note: Please ensure these dependencies are either installed via NuGet or available as DLLs in your project directory._

### Installation

1. **Clone the repository:**

   ```sh
   git clone https://github.com/iskaiflakes/Procurement_Inventory_System.git
   ```

2. **Open the solution in Visual Studio.**
3. **Restore NuGet packages** (if not restored automatically).
4. **Set up your database:**
   - Create the required database and tables as per your organization's needs.
   - Update the connection string in the application's configuration file (`.config`).
5. **Build the solution** to resolve and compile all dependencies.

### Running the Application

- Run the application from Visual Studio (`F5`) or execute the compiled `.exe` in the `bin/Debug` directory.
- Login as an appropriate user role to access respective features (Admin, Approver, etc.).

## Usage

The system provides different forms/windows for:
- Managing purchase requests and orders
- Quotation review and supplier management
- Invoice generation and processing
- Inventory and supply request management
- Administrative operations (user management, audit logs, reports)

_Note: Each user role has access to different features and windows (e.g., `AdminWindow`, `ApproverWindow`, `SupplierQuotationPage`, `InvoicePage`, etc.)._

### Example: Viewing Invoices

The `InvoicePage` allows users to view and manage invoices, with queries joining `Invoice`, `Purchase_Order`, `Employee`, and related tables to display comprehensive invoice data.

### Example: Supplier Quotations

The `SupplierQuotationPage` loads and displays quotations from suppliers, joining supplier, item, and department tables for detailed views.

## License

This project is licensed under the **GNU Affero General Public License v3.0**. See the [LICENSE](LICENSE) file for details.

## Contact

For questions, suggestions, or support, please contact the repository owner via GitHub.
