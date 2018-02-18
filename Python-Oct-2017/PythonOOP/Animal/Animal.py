class Animal(object):
    def __init__(self, name):
        self.name = name
        self.health = 100

    def walk(self):
        self.health -= 1
        print "health -1"
        return self

    def run(self):
        self.health -= 5
        print "health -5"
        return self

    def display_health(self):
        print "Health: " + str(self.health)
        return self

animal1 = Animal("Whiskers")
print animal1.name
animal1.display_health().walk().walk().walk().run().run().display_health()

class Dog(Animal):
    def __init__(self, name):
        super(Dog, self).__init__(name)
        self.health = 150
    def pet(self):
        self.health += 5
        return self

print "-"*100
dog1 = Dog("Spot")
print dog1.name
dog1.display_health().walk().walk().walk().run().run().pet().display_health()

class Dragon(Animal):
    def __init__(self, name):
        super(Dragon, self).__init__(name)
        self.health = 170
    def fly(self):
        self.health -= 10
        print "health -10"
        return self
    def display_health(self):
        super(Dragon, self).display_health()
        print "I am a Dragon"
        return self

print "-"*100
dragon1 = Dragon("Puff")
print dragon1.name
dragon1.display_health().fly().fly().fly().display_health()

class Fish(Animal):
    def __init__(self, name):
        super(Fish, self).__init__(name)
        self.health = 20
    def eat(self):
        self.health += 1
        print "health +1"
        return self

print "-"*100
fish1 = Fish("Nemo")
print fish1.name
fish1.display_health().eat().eat().eat().eat().eat().display_health()
try:
    fish1.pet() # should error since this wasn't inherited
except:
    try:
        fish1.fly() # should error since this wasn't inherited
    except:
        print "Both methods, fish1.pet() & fish1.fly(), caught an exception since they weren't inherited from the parent class"

print "-"*100
try:
    dog1.fly()
except:
    print "Method dog1.fly() also caught an exception since it wasn't inherited"
