def calculate_voltage(current, resistance):

    return current * resistance

def calculate_current(voltage, resistance):

    raise NotImplementedError("Výpočet proudu není implementován.")

def calculate_resistance(voltage, current):

    raise NotImplementedError("Výpočet odporu není implementován.")

def ohms_law(voltage=None, current=None, resistance=None):

    if voltage is None and current is not None and resistance is not None:

        return calculate_voltage(current, resistance)
    elif current is None and voltage is not None and resistance is not None:

        return calculate_current(voltage, resistance)
    elif resistance is None and voltage is not None and current is not None:

        return calculate_resistance(voltage, current)
    else:
        raise ValueError("Musíte zadat dvě veličiny, aby se mohla třetí dopočítat.")


try:
    current = int(input("Zadejte proud:"))
    resistance = int(input("Zadejte odpor:"))
    result = ohms_law(current=current, resistance=resistance)
    print(f"Napětí: {result} V")
except NotImplementedError as e:
    print(e)
except ValueError as e:
    print(e)
