# Checks None checks in Python code
# Variable assignment without check
unsafe_value = None


# Safe: Explicit None check with `is`
if unsafe_value is None:
    print("Data is None")


# Safe: Explicit None check with `is not`
if unsafe_value is not None:
    print("Data is not None")