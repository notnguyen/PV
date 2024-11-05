def calc_voltage(R : float, I : float):
    """
    :param R: resistence
    :param I: current
    :return: voltage
    """
    return R*I

def calc_resistence(V : float, I : float):
    """
    :param V: voltage
    :param I: current
    :return: resistence
    """
    if I <= 0:
        raise Exception("Voltage must be positive")
    return V/I

def calc_current(V : float, R : float):
    """
    :param V: voltage
    :param R: resistence
    :return: current
    """
    if R <= 0:
        raise Exception("Resistence must be positive")
    return V/R

def calc_coulomb_law(charge1 : float, charge2 : float, epsilon_r : float, distance : float):
    """
    :param charge1: value of first charge
    :param charge2: value of second charge
    :param epsilon_r: electric constant
    :param distance: distance between charges
    :return:
    """
    epsilon_0 = 0.00000000000885
    epsilon = epsilon_0 * epsilon_r
    force = (1 / (4*3.14*epsilon)) * abs(charge1 * charge2) / (distance ** 2)
    return force