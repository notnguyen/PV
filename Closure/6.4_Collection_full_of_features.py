import random

# Naprogramujte kolekci (treba list) funky funcí, ktery se
# bude jmenovat funky_functions tak aby kolekce obsahovala nasledujici funkce, ktere
# vsechny prijmou jeden string a vrati string:
#
# Funkce, ktera prevete pismena na velka pismena
# Funkce, ktera kazdou mezeru nahradi smajlikem
# Funkce, ktera nahradi kazde pismeno V pismenem W
# Funkce, ktera prida na zacatek i na konec retezce znak *
# Funkce, ktera kazdy znak ?, nebo ! nahradi tremi ??? nebo peti !!!!!
# Napiste funkci funky_format(text), ktera prijme na vstupu text,
# a 3x nahodne vybere funkci funky_functions a kazdou z nich preformatuje text na vstupu
# a vrati vysledek. Zkontrolujte napriklad na tomto kodu:
#
# print(funky_format("Ahoj Karle! Pudeme dnes do kina?"))

def uppercase_text(input):
    """
    A function that converts letters to uppercase
    :param input: string
    :return:
    """
    return input.upper()

def space_to_smiley(input):
    """
    A function that replaces every space with a smiley
    :param input: string
    :return:
    """
    return input.replace(" ", ":)")

def V_to_W(input):
    """
    A function that replaces every letter V with the letter W
    :param input: string
    :return:
    """
    return input.replace("V", "W")

def begin_and_end_with_char(input):
    """
    A function that adds the "*" character to the beginning and end of a string
    :param input: string
    :return:
    """
    return f"* {input} *"

def multiply_char(input):
    """
    A function that each character ?, or ! replace with three ??? or five !!!!!
    :param input: string
    :return:
    """
    return input.replace("?", "???").replace("!", "!!!!!")

funky_functions = [uppercase_text, space_to_smiley, V_to_W, begin_and_end_with_char, multiply_char]

def funky_format(text):
    """
    Function that accepts text as an input and randomly selects funky_functions 3 times
    and reformats the input text with each of them and returns the result.
    :param text: string
    :return:
    """
    for function in range(3):
        function = random.choice(funky_functions)
        text = function(text)
    return text

print(funky_format("Ahoj Karle! Pudeme dnes do kina?"))