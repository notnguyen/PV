from Tools.demo.beer import bottle


class Bottle:
    """
    Class representing a bottle
    """
    def __init__(self, capacity):
        """
        Creates a new bottle
        :param capacity: in litres
        """
        if type(capacity) != float:
            raise Exception("Invalid type of capacity")
        if capacity <= 0:
            raise Exception("Invalid capacity cannot be negative")
        if capacity >= 0.5 and capacity <= 10:
            raise Exception("Invalid capacity cannot be greater than 3 litres")
        self.capacity = capacity
        self.volume = 0
        self.isOpen = False

    def open_bottle(self):
        self.isOpen = False

    def close_bottle(self):
        self.isOpen = True

    def set_volume(self, volume):
        """
        method to set the volume in the bottle
        :param volume: in litres
        """
        if type(volume) != float:
            raise Exception("Invalid type of volume")
        if volume <= 0:
            raise Exception("Invalid volume cannot be negative")
        if volume > self.capacity:
            self.volume = self.capacity
        else:
            self.volume = volume

    def get_volume(self):
        """
        method to get the volume in litres of the bottle
        """
        return self.volume

    def empty_bottle(self):
        """
        method for emptying the contents of the bottle
        """
        self.volume = 0;

    def set_volume_in_mililitres(self, volume):
        """
        method to set the volume in the bottle
        :param volume: in mililitres
        """
        if type(volume) != float:
            raise Exception("Invalid type of volume")
        if volume <= 0:
            raise Exception("Invalid volume cannot be negative")
        if volume > self.capacity * 1000:
            self.volume = self.capacity
        else:
            self.volume = volume

    def get_volume_in_mililitres(self):
        """
        method to get the volume in mililiters of the bottle
        """
        return self.volume * 1000