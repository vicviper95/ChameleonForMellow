# 🦎 Chameleon – Intelligent Warehouse Stock Distribution System

**Chameleon** is a smart inventory allocation and distribution system designed to optimize warehouse stock feeding across major e-commerce platforms like **Amazon, Walmart, Wayfair, Overstock, HomeDepot, and Target**.

## 🛠️ Purpose

Built to eliminate manual stock planning, **Chameleon** automates decision-making by analyzing sales data, market demand, and custom business rules — ensuring efficient, scalable, and data-driven distribution.

## 💡 Key Features

- 📊 **Sales-Based Allocation**  
  Uses ABC Pareto logic based on 3 years of historical sales data to calculate stock quantities for each marketplace.

- ⚙️ **Custom Rule Engine**  
  Supports market-specific strategies like:

  - Priority for top-selling SKUs (e.g., Walmart Top 15)
  - Adjustable on/off ratios by season or event
  - Per-market custom logic (e.g., hold back, extra boost)

- 🔁 **Automated Syncing**  
  Integrates with vendor APIs and feeds data to platforms like Amazon, Wayfair, and others using RESTful APIs and custom schedulers.

- 🧱 **Tech Stack**
  - Backend: C#, ASP.NET
  - Database: MS SQL Server (including stored procs & ETL logic)
  - Frontend: jQuery, HTML/CSS
  - Reporting: Power BI-ready data views

## 🔐 Infrastructure Enhancements

- Built-in version control with GitHub
- Backup SQL server for data mining & reporting
- Data warehouse for historical price and stock tracking

## 🙋‍♂️ My Role

I led the development of Chameleon from concept to deployment:

- Designed and implemented database schema and business logic
- Created RESTful APIs for inter-vendor data communication
- Managed infrastructure and automated backup systems
- Developed front-end UI for internal stock managers

---

Feel free to explore the source code or contact me for more details.
