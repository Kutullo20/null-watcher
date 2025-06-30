# Null Safety Rule for Python Code
# Curently checks on a sigle line, not multiple lines
# Curretly uses a simple check for "None" without "!=" or "==" [Comparison Operators]

data = None  # Should raise an issue - must be flagged
print(data)  # No check before use 

if data != None:  # Explicit None check (safe)  
    print("Data exists")

if data == None:  # Explicit None check (safe)  
    print("Data does not exist")

