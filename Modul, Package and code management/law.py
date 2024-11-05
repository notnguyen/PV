def calc_voltage(current, resistance):
    """
    Calculate voltage according to Ohm's law
    :param current: proud v amperech
    :param resistance: odpor v ohmech
    :return: napeti ve voltech
    """
    return current * resistance

def calc_current(voltage, resistance):
    """
    Calculate current according to Ohm's law'
    :param voltage: napeti ve voltech
    :param resistance: odpor v ohmech
    :return: proud v amperech
    """
    return voltage / resistance

def calc_resistance(voltage, current):
    """
    Calculate resistance according to Ohm's law'
    :param voltage: napeti ve voltech
    :param current: proud v amperech
    :return: odpor v ohmech
    """
    return  voltage / current


def ohms_law(voltage, current, resistance):
    """
    Calculate Ohms law
    :param voltage:
    :param current:
    :param resistance:
    :return:
    """

    if voltage is None and current is not None and resistance is not None:

        return calc_voltage(current, resistance)
    elif current is None and voltage is not None and resistance is not None:

        return calc_current(voltage, resistance)
    elif resistance is None and voltage is not None and current is not None:

        return calc_resistance(voltage, current)
    else:
        raise ValueError("You must enter two quantities so that the third can be calculated.")


def calc_coulombs_law(q1, q2, r, epsilon_r):
    """
    Calculate Coulombs law
    :param q1:
    :param q2:
    :param r:
    :return:
    """
    epsilon_0 = 0.00000000000885
    epsilon = epsilon_0 * epsilon_r
    force = (1 / (4 * 3.14 * epsilon)) * abs(q1 * q2) / (r ** 2)
    return force





