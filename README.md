# Driving & Vehicle License Department (DVLD) System V1.0

## 📌 Project Overview
The Driving & Vehicle License Department (DVLD) System is a comprehensive, multi-tier desktop application designed to automate and streamline the entire lifecycle of driving license issuance and management. Built using **C#**, **Windows Forms**, **SQL Server**, and **ADO.NET**, this system transitions traditional, paperwork-heavy licensing processes into a secure, efficient, and fully digitized workflow.

This isn't just a basic CRUD application. It is an enterprise-grade solution engineered with a **Strict 3-Tier Architecture (Data Access, Business Logic, and Presentation Layers)** to ensure absolute separation of concerns, high scalability, and clean, maintainable code.

---

## 📌 Database Architecture ScreenShot (01)<img width="1518" height="838" alt="ScreenShot(01)" src="https://github.com/user-attachments/assets/feca4c7d-c5be-434c-a30e-b25b0b24cdb7" />



The database features a highly normalized relational schema designed around a **Person-centric core** to enforce strict data integrity. It flawlessly connects five integrated modules: User Security, Application Lifecycle, Multi-Stage Testing (Vision/Theory/Practical), Driver Licensing, and Asset Enforcement (Detained Licenses). Every transactional relationship uses Primary and Foreign Keys to automate complex real-world licensing business rules seamlessly.

---

## 🔐 1. Login Screen Screenshot (02)<img width="797" height="450" alt="ScreenShot(02)" src="https://github.com/user-attachments/assets/f85a1e78-443d-47da-bab8-d9c225f119d2" />

* **Concept:** Secure gateway for system operators.
* **Core Logic:** Verifies user credentials against database records while enforcing safety checks via the `IsActive` flag. Includes an encrypted "Remember Me" local storage feature.
* **Tech Highlight:** Strict UI-level data validation before hitting the Business Logic Layer (BLL).

---

## 🖥️ 2. Main Dashboard Screenshot (03)<img width="1913" height="1050" alt="ScreenShot(03)" src="https://github.com/user-attachments/assets/a3ce9d5d-b48b-4280-9979-f090023860f7" />

**Concept:** The system's central navigation hub providing role-based access to 5 core modules:
* **Applications:** Automates the licensing lifecycle (New Requests, Tests, Renewals, Replacements, and Asset Releases).
* **People:** Centralized CRUD registry managing citizen data, strictly uniquely identified via National IDs.
* **Drivers:** Tracks full driving histories, violations, and active/expired licenses for cleared individuals.
* **Users:** Administrative panel for managing employee accounts, credentials, and system access permissions.
* **Account Settings:** Self-service profile management for password updates and active session metadata.

---

## 👥 3. Manage People Screen Screenshot (04)<img width="1920" height="1080" alt="ScreenShot(04)" src="https://github.com/user-attachments/assets/87e133b3-5443-4efd-a926-fdccfff43991" />

* **Concept:** The central base registry. Every User or Driver must be registered here first.
* **Core Logic:** Provides full CRUD operations, live data filtering (by National ID/Name), and a quick shortcut to register new citizens.
* **Tech Highlight:** Decoupled data fetching via the Business Layer to keep the `DataGridView` highly responsive.

### 📑 3.1 Context Menu (Manage People) Screenshot (05)<img width="1920" height="1080" alt="ScreenShot(05)" src="https://github.com/user-attachments/assets/72cf1326-c794-4bca-bed4-7bcd4205804f" />

* **Concept:** Contextual right-click menu tailored to optimize User Experience (UX) for fast record interaction.
* **Core Logic:** Provides direct actions on the selected row: View full Person details, Edit Person Information, or Delete Person, alongside communication shortcuts (Send Email and Phone Call).
* **Tech Highlight:** Dynamically captures the selected row's `PersonID` and passes it seamlessly to the Business Logic Layer (BLL) to execute operations and refresh the UI instantly.

---

## 👤 4. Add/Edit Person Info Screenshot (06)<img width="1920" height="1080" alt="ScreenShot(06)" src="https://github.com/user-attachments/assets/86b01f06-efc4-4809-ab51-c9ff4b20984d" />

* **Concept:** A dual-purpose, transactional form designed to seamlessly handle both registering new individuals and updating existing profiles.
* **Core Logic:** Enforces full field coverage, including complex personal metadata (Full Name fields, unique National ID, Date of Birth constraints, and profile picture handling).
* **Tech Highlight:** Implements an aggressive client-side validation system via `ErrorProvider`. This prevents database null-insertion or format failures by strictly blocking the save operation until all real-time input criteria are satisfied.

---

## 👥 5. Manage Users Screen Screenshot (07)<img width="1920" height="1080" alt="ScreenShot(07)" src="https://github.com/user-attachments/assets/2c6d76ce-68f3-431f-8514-aa720835d78a" />

* **Concept:** Administrative panel to manage system operators (employees) authorized to access and interact with the application.
* **Core Logic:** Maps user credentials directly to existing records in the People registry via `PersonID` while displaying account activation status (`IsActive`).
* **Tech Highlight:** Enforces strict relational database integrity (1:1 person-to-user mapping) and provides live data filtering for efficient account administration.

### 📑 5.1 Context Menu (Manage Users) Screenshot (08)<img width="1920" height="1080" alt="ScreenShot(08)" src="https://github.com/user-attachments/assets/d4ce31e6-79c6-4497-92ab-d092687333ba" />

* **Concept:** Security and account management shortcut menu tailored for administrative control over system operators.
* **Core Logic:** Enables fast account lifecycle actions directly on the selected user row: Delete User, Edit User, Show Details, and contact shortcuts (Send Email, Phone Call).
* **Tech Highlight:** Includes a critical "Change Password" logic gateway to securely trigger administrative overrides.

---

## 👤 6. Add New User Info Screenshot (09)<img width="1920" height="1080" alt="ScreenShot(09)" src="https://github.com/user-attachments/assets/210f9374-45f0-41bc-b5d9-e4aa43b28483" />

* **Concept:** A multi-step wizard interface designed to elevate an existing citizen record into an active system operator.
* **Core Logic:** Implements a two-phase pipeline using tabs:
  * **Person Info Tab:** Searches and loads a specific person profile via National ID or Person ID filters using a reusable user control.
  * **Login Info Tab:** Defines operator credentials, specifies the unique username, and manages account activation permissions.
* **Tech Highlight:** Enforces a strict database validation check to prevent multiple user accounts from being linked to the same `PersonID` (1:1 relational enforcement).

### 🔑 6.1 Login Info Tab Screenshot (10)<img width="1920" height="1080" alt="ScreenShot(10)" src="https://github.com/user-attachments/assets/94aeb377-5072-4a59-b794-3658532904be" />

* **Concept:** The second stage of the User Creation Wizard, explicitly isolating access credentials from personal demographics.
* **Core Logic:** Handles input collection for the unique Username, Password hashing/validation, and toggles system access rights through the `IsActive` checkbox.
* **Tech Highlight:** Implements strict data validation to ensure the password and confirmation match exactly, blocking save actions at the UI level if any security criteria fail.

---

## 🔑 7. Account Settings Menu Screenshot (11)<img width="1920" height="1080" alt="ScreenShot(11)" src="https://github.com/user-attachments/assets/ccd94772-cb7c-44e1-bf33-0fb39ec40089" />

* **Concept:** A contextual self-service menu dedicated to the currently authenticated system operator.
* **Core Logic:** Provides direct access to personal session management through three essential workflows: viewing personal/professional metadata (Current User Info), triggering credential updates (Change Password), and securely terminating the active session (Sign Out).
* **Tech Highlight:** Dynamically relies on global session state properties (like a globally shared `CurrentUser` object) to trace user identity across the system securely.

---

## 📋 8. Applications Menu Navigation Screenshot (12)<img width="1920" height="1080" alt="ScreenShot(12)" src="https://github.com/user-attachments/assets/ecf95f3a-0b9e-4167-afc5-e875b0ef446a" />

**Concept:** The primary entry point for managing the core business workflows of the licensing department.
**Core Logic:** Exposes 5 dynamic data-driven sub-menus to orchestrate the entire license lifecycle:
* **Driving License Services:** Gateway for issuing new, renewed, replacement, or international licenses.
* **Manage Applications:** Central tracker for processing local and international license requests.
* **Detain License:** Sub-system to handle traffic violations, license suspensions, and release penalties.
* **Manage Application Types:** Administrative lookup table configuration to manage application categories and processing fees.
* **Manage Test Types:** Administrative control panel to set up and price required driving test stages (Vision, Written, Practical).

### 📑 8.1 Manage Applications Sub-Menu Screenshot (13)<img width="1920" height="1080" alt="ScreenShot(13)" src="https://github.com/user-attachments/assets/fc3df1a0-fba7-41f7-9942-77bf25c511f1" />

* **Concept:** Specialized routing menu designed to isolate and track license requests based on geographical and regulatory jurisdictions.
* **Core Logic:** Splits the workflow into two distinct processing pipelines:
  * **Local Driving License Applications:** Manages standard domestic licenses, binding them to specific vehicle classes and tracking mandatory test stages.
  * **International License Applications:** Processes global permits for existing local drivers, cross-referencing active local licenses without repeating test pipelines.
* **Tech Highlight:** Acts as a business logic gateway to ensure cleaner separation of concerns.

---

## 📄 9. Local Driving License Applications Screenshot (14)<img width="1920" height="1080" alt="ScreenShot(14)" src="https://github.com/user-attachments/assets/8912c37a-3f3a-45e7-ab53-9ca7b6e2bd01" />

* **Concept:** The primary command center for monitoring and advancing domestic driving license requests through their legal lifecycles.
* **Core Logic:** Consolidates multi-table relational data to display comprehensive application metrics, including the specific license category (Driving Class), the total milestones met (Passed Tests counter out of 3), and the real-time operational state (New, Completed, Cancelled).
* **Tech Highlight:** Acts as a state machine tracking system. It dynamically feeds data from complex SQL Server views/joins down to the UI, layout-coded with visual indicators (like custom row colors) to maximize operator efficiency.

### 📑 9.1 Context Menu — "New" Status Actions Screenshot (15)<img width="1920" height="1080" alt="ScreenShot(15)" src="https://github.com/user-attachments/assets/dcc3fed7-448d-48db-a03b-1dcddc71f6d2" />

* **Concept:** A smart right-click menu that changes its choices based on whether the application is new, completed, or canceled.
* **Core Logic (For New Applications):** When an application is still New and the applicant hasn't finished all 3 required tests:
  * **Allowed Actions:** The user can view details, edit info, delete, cancel the application, or book the next exam using *Schedule Test*.
  * **Blocked Actions:** The system automatically locks the options to *Issue Driving License* or *Show License*. This ensures no license can be created by mistake until all tests are successfully passed.
* **How it works:** The system checks the application status and the number of passed tests first, then automatically opens or locks the menu options accordingly.

### 📑 9.2 Sequential Testing System Screenshot (16)<img width="1920" height="1080" alt="ScreenShot(16)" src="https://github.com/user-attachments/assets/097d5761-709f-4819-9107-41ad48e1a97e" />

* **Concept:** A strict step-by-step testing ruleset that prevents applicants from jumping ahead or skipping mandatory exams.
* **Core Logic (The 3-Test Chain):** The system enforces a fixed order for the three required driving tests:
  1. **Vision Test:** The absolute starting point for any new application.
  2. **Written Test:** Completely locked and unavailable until the applicant successfully passes the Vision Test.
  3. **Street Test:** The final stage, which remains locked until the applicant passes the Written Test.
* **How it works:** When clicking *Schedule Test*, the menu automatically looks at which exams the applicant has already passed. It then only opens the single next exam in line, keeping the rest locked to prevent any mistakes.

### 📑 9.3 Issue License Action (Upon Passing All Tests) Screenshot (17)<img width="1920" height="1080" alt="ScreenShot(17)" src="https://github.com/user-attachments/assets/75f9070e-49c8-47e5-a721-8c9fb2c29af2" />

* **Concept:** A smart context menu that automatically opens up advanced legal actions for the operator as soon as the applicant meets all requirements.
* **Core Logic (For Passed Applications):** When an applicant successfully completes all 3 required driving tests (Passed Tests = 3):
  * **Enabled Actions:** The system automatically unlocks the "Issue Driving License [First First Time]" option, which is the final step allowing the operator to officially generate the driver's license.
  * **Disabled Actions:** The *Schedule Test* menu is completely locked, since there are no remaining exams left for the applicant to take.
* **How it works:** The system strictly prevents issuing any license by mistake. It verifies the database records first and only displays the issue option when all three examination stages are successfully cleared.

### 📑 9.4 Context Menu — "Completed" Status Actions Screenshot (18)<img width="1920" height="1080" alt="ScreenShot(18)" src="https://github.com/user-attachments/assets/ec90672e-8cce-4d53-acea-59ad048f24c0" />

* **Concept:** Automatically locks down all application modifications once a license has been successfully generated, shifting the options toward viewing and history.
* **Core Logic (For Completed Applications):** When an application's status changes to Completed (meaning the driving license has been issued successfully):
  * **Enabled Actions:** The system opens up "Show License" to view the active driving license details and "Show Person License History" to check the driver's complete history.
  * **Disabled Actions:** To protect data integrity, the system completely locks all editing, deleting, canceling, testing (Schedule Test), and issuance options (Issue Driving License).
* **How it works:** Once a license is officially issued, the application record becomes permanent. The system updates the menu items automatically, so operators can only view the final outcomes without accidentally changing any passed data.

---

## 📑 10. Test Appointments Management (e.g., Street Test) Screenshot (19)<img width="1920" height="1080" alt="ScreenShot(19)" src="https://github.com/user-attachments/assets/466c6def-b6a4-48a3-9f27-cb69d9ce7ea9" />

* **Concept:** A unified, reusable management screen used across all three examination stages (Vision, Written, and Street) to view application summaries and track scheduled test dates.
* **Core Logic:** The screen layout dynamically adapts to the selected test stage while focusing on three key areas:
  * **Driving License Application Info:** Displays top-level metrics, including the Local ApplicationID, target vehicle class, and the current test progress counter (e.g., Passed Tests = 2/3).
  * **Application Basic Info:** Shows administrative background details such as the application date, paid processing fees ($15), current status, and the applicant's name with a quick link to look up their personal card information.
  * **Appointments Grid:** A clean data list at the bottom that tracks all historical and upcoming test dates reserved for this specific applicant, ensuring no duplicate active appointments can be made.
* **How it works:** This layout acts as a central hub before booking or entering test scores. Operators can review the full status of the applicant at a glance and click the "Add Appointment" calendar icon to open the scheduling screen.

### 📑 10.1 Test Scheduling Wizard Screenshot (20)<img width="1920" height="1080" alt="ScreenShot(20)" src="https://github.com/user-attachments/assets/829907a1-2934-4a32-9a9c-f7056208a1ea" />

* **Core Logic & Validations:**
  * **Active Appointment Lock:** The system strictly checks the database before opening this screen. If the applicant already has an active, unresolved test appointment for the same test type, the system blocks the user from creating a new one.
  * **Test Details Display:** Automatically pulls and presents the ApplicationID, target vehicle class, the applicant's name, and the current trial counter (Trial starts at 0 for the first attempt).
  * **Dynamic Retake Logic:** Features a conditional "Retake Test Info" section at the bottom. If the applicant failed a previous attempt, this section unlocks to calculate re-examination fees dynamically.
* **How it works:** The operator simply selects a future date from the calendar control and clicks "Save". This logs the appointment into the database and updates the historical records grid in the background.

### 📑 10.2 Managing Scheduled Appointments Screenshot (21)<img width="1920" height="1080" alt="ScreenShot(21)" src="https://github.com/user-attachments/assets/a60dde86-8a7e-48b5-b2ca-df19cf71aae5" />

* **Concept:** A right-click menu to manage booked time slots from the appointments list.
* **Core Actions:**
  * **Edit:** Changes the date or details of the scheduled appointment.
  * **Take Test:** Opens the results screen to record whether the applicant passed or failed.
* **How it works:** Gives operators immediate control to either update schedules or push the applicant forward to enter their exam result.

### 📑 10.3 Recording Test Results Screenshot (22)<img width="1920" height="1080" alt="ScreenShot(22)" src="https://github.com/user-attachments/assets/7f0d3d70-c455-4984-b19d-9744dd9ebb1e" />

* **Concept:** A simple dialog for examiners to submit the pass or fail outcome of a scheduled driving test.
* **Core Actions:**
  * **Result Selection:** Radio buttons to mark the test as Pass or Fail.
  * **Notes Field:** An optional text box for examiner comments.
* **How it works:** Saving the result instantly updates the database, updates the Passed Tests counter if they passed, and locks the appointment.

---

## 📑 11. International Driving License Applications Screenshot (23)<img width="1920" height="1080" alt="ScreenShot(23)" src="https://github.com/user-attachments/assets/26f07fc6-370c-406b-9347-3d225ac950d4" />

* **Concept:** A management screen to view and monitor all issued international driving licenses.
* **Key Data Fields:** Tracks international license IDs, linked Driver and Local License IDs, issue/expiration dates, and current active status.
* **How it works:** Provides a central grid for operators to audit international permits and ensure they are backed by valid local driving license blueprints.

### 📑 11.1 International License Context Menu Screenshot (24)<img width="1920" height="1080" alt="ScreenShot(24)" src="https://github.com/user-attachments/assets/f55f04f1-fdee-4c57-8980-b5389df4bb25" />

* **Concept:** A specialized right-click menu tailored strictly for viewing issued international permit records.
* **Core Actions:**
  * **Show Person Details:** Opens the license holder's personal identity profile.
  * **Show License:** Displays the active international driving license document.
  * **Show Person License History:** Reviews all local and international license logs for this individual.
* **How it works:** Hides all editing and management controls to prevent data modification once the permit is legally generated.

---

## 📑 12. Driving License Services Menu Screenshot (25)<img width="1920" height="1080" alt="ScreenShot(25)" src="https://github.com/user-attachments/assets/13b7c66c-e9e4-43eb-97a2-e45f427023f5" />

* **Concept:** A centralized navigation dropdown that hosts all transactional workflows related to a driver's license lifecycle.
* **Available Services:**
  * **New Driving License:** The starting point to issue a brand new local or international permit.
  * **Lifecycle Management:** Dedicated options to handle routine updates like Renew Driving License, or replacing lost/damaged documents (Replacement for Lost or Damaged License).
  * **Enforcement & Retakes:** Administrative shortcuts to manage Release Detained Driving License or log a Retake Test entry.
  * **How it works:** Acts as a secure, role-based control panel where operators can immediately launch any core license-related sub-system from a single interface.

---

## 📑 13. Detain License Services Menu Screenshot (26)<img width="1920" height="1080" alt="ScreenShot(26)" src="https://github.com/user-attachments/assets/0d83c534-3f64-4dc5-99ce-ee1e42d28572" />

* **Concept:** A specialized control menu used to manage penal actions, holds, and legal releases on active driving licenses.
* **Core Options:**
  * **Manage Detain License:** A tracking sub-system to look up, filter, and audit all historically and currently detained licenses.
  * **Detain License:** The operational wizard used to physically place a legal hold/freeze on a specific license card.
  * **Release Detained License:** The payment and clearance screen used to collect fines and officially lift the detention hold.
* **How it works:** Provides an organized administrative portal to enforce traffic department penalties and manage the restricted lifecycle of flagged drivers.

---

## 📑 14. List Detained Licenses Management Screenshot (27)<img width="1920" height="1080" alt="ScreenShot(27)" src="https://github.com/user-attachments/assets/46a912f2-daa2-49d9-a128-79f029e2e46d" />

* **Concept:** A central grid window used to log, monitor, and manage traffic violation holds placed on driving licenses.
* **Core Interface elements:**
  * **Top Action Buttons:** Quick launch shortcuts to physically Detain License (red stop icon) or Release Detained License (green check icon).
  * **Data Ledger:** Tracks crucial details, including DetainID, LicenseID, fine amounts, release dates, and the current state via the Released checkbox.
  * **Context Menu Actions:** Right-click options designed for easy viewing, including Show Person Details, Show License, and Show Person License History.
* **How it works:** Provides an audit logging space for enforcement officers to search through penalized drivers and manage pending or settled legal fines.

### 📑 14.1 Detain License Process Screenshot (28)<img width="1920" height="1080" alt="ScreenShot(28)" src="https://github.com/user-attachments/assets/eca200f8-5baa-478c-b58b-cce4f3d0d550" />

* **Concept:** An administrative wizard used to search for an active driving license and officially place a legal detention hold on it with assigned fine fees.
* **Core Interface Sections:**
  * **License Filter:** A top search panel allowing operators to look up any driver using their unique License ID.
  * **Driver License Info:** A read-only verification area that populates cardholder details, expiration metrics, and current status flags.
  * **Detain Info:** The functional zone where the system logs the dynamic Detain ID, date, creator ID, and requires inputting the mandatory penalty amount (Fine Fees).
* **How it works:** Once a valid license is fetched and the fine is assigned, clicking the Detain button locks the license card state in the database, blocking the driver from using it until it is officially cleared.

### 📑 14.2 Release Detained License Process Screenshot (29)<img width="1920" height="1080" alt="ScreenShot(29)" src="https://github.com/user-attachments/assets/6831c9ed-dde6-4d24-9156-3a12d9bd73de" />

* **Concept:** A clearance wizard to look up a detained license, calculate penalties, and process the financial release.
* **Core Interface Sections:**
  * **License Filter & Info:** Locates the restricted driver and confirms the restriction state (Is Detained? = Yes).
  * **Info & Fees:** Dynamically sums the total clearance cost. Once paid and released, the system clears the detention flag, switches the card state back to active.

---

## 📑 15. Manage Application Types Screenshot (30)<img width="1920" height="1080" alt="ScreenShot(30)" src="https://github.com/user-attachments/assets/b3df4e38-6a43-49a1-9bac-1379f3f3be51" />

* **Concept:** An admin screen to view and configure dynamic fees for all application types.
* **Key Data Fields:** Tracks service titles (e.g., Renewals, International Licenses) and their current pricing structure (Fees).
* **How it works:** Centralizes service management to ensure consistent billing across all system modules.

---


## 📑 16. Manage Test Types Screenshot (31)<img width="1920" height="1080" alt="ScreenShot(31)" src="https://github.com/user-attachments/assets/6f475920-b05b-4b93-9555-b6174192e78b" />

* **Concept:** An admin lookup screen to manage the core verification exams required for a driving license.
* **Key Data Fields:** Tracks the three main stages (Vision, Written, and Practical Tests) along with their official descriptions and current dynamic fees.
* **How it works:** Centralizes exam definitions to ensure consistent setup and uniform pricing across all booking modules.
