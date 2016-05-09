from random import randint as rand

class SomeInterestingClass:
	def __init__(self):
		self.observers = []
	
	def addobserver(self, o):
		self.observers.append(o)
	
	def notifyobservers(self, event):
		for o in self.observers:
			o.dosomething(event)
	
	def actionA(self):
		self.notifyobservers('action A')
	
	def actionB(self):
		self.notifyobservers('action B')
			
	def work(self):
		for i in range(10):
			print("Im interesting and Im gonna do something...")
			
			if rand(1, 2) == 1:
				self.actionA()
			else:
				self.actionB()
			
			print("")

class SomeCuriousClass:
	def __init__(self, name):
		self.name = name

	def dosomething(self, event):
		print("observer %s handled event %s" % (self.name, event))

interestingThing = SomeInterestingClass()

interestingThing.addobserver(SomeCuriousClass("three"))
interestingThing.addobserver(SomeCuriousClass("two"))
interestingThing.addobserver(SomeCuriousClass("one"))

interestingThing.work()