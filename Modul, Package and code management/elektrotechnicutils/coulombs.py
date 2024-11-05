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