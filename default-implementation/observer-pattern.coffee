class SomeInterestingClass
  constructor: ->
    @observers = []
    
  addObserver: (o) ->
    @observers.push o
  
  notifyObservers: (event) ->
    o.doSomething(event) for o in @observers
  
  actionA: ->
    @notifyObservers 'action A'
  
  actionB: ->
    @notifyObservers 'action B'
  
  random: ->
    Math.floor(Math.random() * 2)
  
  work: ->
    for i in [1..10]
      console.log 'Im interesting and Im gonna do something...'
      
      if @random() is 1 then @actionA() else @actionB()
    
      console.log ''

class SomeCuriousClass
  constructor: (@name) ->
  
  doSomething: (event) ->
    console.log "observer #{@name} handled event #{event}"

interestingThing = new SomeInterestingClass

interestingThing.addObserver new SomeCuriousClass "one"
interestingThing.addObserver new SomeCuriousClass "two"
interestingThing.addObserver new SomeCuriousClass "three"

interestingThing.work()