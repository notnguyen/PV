import law

# Vytvořte v jednom souboru modul, který bude obsahovat funkce, třídy
# nebo další prvky potřebné k výpočtu Ohmova zákona.
# Modul zdokumentujte a připravte skript v druhém souboru, který
# importuje Váš modul a vypočte níže uvedné příklady:
#
# U=10mV, R=1KiloOhm, kolik je proud?
# Namerite-li proud 2mA a napeti 3V, jaka musi byt hodnota R?
# Je-li R=2Ohmy a proteka-li prodou 20miliAmper, jake je napeti?

voltage = 10e-3
resistance = 1e3
current = law.calc_current(voltage,resistance)
print(current)




