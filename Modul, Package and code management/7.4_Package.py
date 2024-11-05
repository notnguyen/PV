import elektrotechnicutils.ohm
from elektrotechnicutils.ohm import *

voltage = 10e-3
resistance = 1e3
current = elektrotechnicutils.ohm.calc_current(voltage,resistance)
print(current)

voltage = 10e-3
resistance = 1e3
current = calc_current(voltage,resistance)
print(current)

