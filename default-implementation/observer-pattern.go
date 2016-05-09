package main

import (
    "fmt"
    "math/rand"
)

type Observer interface {
    DoSomething(event string)
}

type SomeInterestingStruct struct {
    Observers []Observer
}

type SomeCuriousStruct struct {
    name string
}

func (sis *SomeInterestingStruct) AddObserver(o Observer) {
    (*sis).Observers = append(sis.Observers, o)
}

func (sis SomeInterestingStruct) NotifyObservers(event string) {
    for _, o := range sis.Observers {
        o.DoSomething(event)
    }
}

func (sis SomeInterestingStruct) ActionA() {
    sis.NotifyObservers("action A")
}

func (sis SomeInterestingStruct) ActionB() {
    sis.NotifyObservers("action B")
}

func (sis SomeInterestingStruct) Work() {
    for i := 0; i < 10; i++ {
        fmt.Println("Im interesting and Im gonna do something...")
        
        if rand.Intn(2) == 1 {
            sis.ActionA()
        } else {
            sis.ActionB()
        }
        
        fmt.Println()
    }
}

func (cur SomeCuriousStruct) DoSomething(event string) {
    fmt.Println("observer", cur.name, "handled event", event)
}

func main() {
    interesting := SomeInterestingStruct{Observers: make([]Observer, 0)}
    
    interesting.AddObserver(SomeCuriousStruct{name: "one"})
    interesting.AddObserver(SomeCuriousStruct{name: "two"})
    interesting.AddObserver(SomeCuriousStruct{name: "three"})
    
    fmt.Println(len(interesting.Observers))
    
    interesting.Work()
}