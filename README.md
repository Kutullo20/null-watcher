# 🕵️Static Null Checker 
### This project is a basic null safety checker built with .NET, designed to scan and detect risky null usages across three major programming languages:
- Java
- Python
- C#

## ⚙️ How It Works 
- 🧾 Reads each line of code from the file being analyzed.
- 🕵️‍♀️ Ignores null keywords inside strings (e.g. "null" or 'None') so only actual code is checked and comments(e.g. #None.)
- 🔍 Looks for risky patterns, such as: null in Java or C# without **==** or **!=** checks
- 🔍 Looks for risky patterns, such as: None in Python without **is** or **is not** checks

## ⚠️ Key Limitations
- ⚠️ The rule checks one line at a time, not the whole file as a logical block
- ⚠️ it cannot tell whether a risky value is later handled
- ⚠️ It does not remember what happened on previous or next lines

## 📋 Objectives of this project 

**The objective of this project is to Demostrate the following skills:**
- 🧾 **Documentation** - Structured codebase guide for other developers/stakeholders
- ⚙️ **Version Control & Incremental workflow** - Divided the project into small pieces with git braching strategy 
- 🛠️ **Maintainable Solution** -  Designed with a single responsibility per rule, making the codebase easier to read, test, and update without affecting other parts
- 🧩 **Extensible Solution**  - Built with a plug-and-play structure, allowing new languages to be added without touching the core logic
- 🌐 **Cross-Language Integration** – Supports Java, Python, and C# for consistent null safety checks across multiple languages.


