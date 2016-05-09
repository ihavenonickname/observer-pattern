class SomeInterestingClass
	def initialize()
		@observers = []
	end
	
	def add_observer o
		@observers.push o
	end
	
	def notify_observers event
		@observers.each { |o| o.do_something event }
	end
	
	def action_A
		notify_observers 'action A'
	end
	
	def action_B
		notify_observers 'action B'
	end
	
	def work
		10.times do
			puts "Im interesting and Im gonna do something..."
			
			if Random.new().rand(2) == 0 then
				action_A()
			else
				action_B()
			end
				
			puts
		end
	end
end

class SomeCuriousClass
	def initialize name
		@name = name
	end

	def do_something event
		puts "observer #{@name} handled event #{event}"
	end
end

interestingThing = SomeInterestingClass.new

interestingThing.add_observer SomeCuriousClass.new "one"
interestingThing.add_observer SomeCuriousClass.new "two"
interestingThing.add_observer SomeCuriousClass.new "three"

interestingThing.work()