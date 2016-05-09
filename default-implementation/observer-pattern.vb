Module AnaliseDeSistemas

	Public Interface IObserver
		Sub DoSomething(ByVal _event As String)
	End Interface

	Private Class SomeInterestingClass
		Private observers As New List(Of IObserver)

		Public Sub AddObserver(ByVal o As IObserver)
			observers.Add(o)
		End Sub

		Private Sub notifyObservers(ByVal _event As String)
			For Each o In observers
				o.DoSomething(_event)
			Next
		End Sub

		Public Sub ActionA()
			notifyObservers("action A")
		End Sub

		Public Sub ActionB()
			notifyObservers("action B")
		End Sub

		Public Sub Work()
			For i = 1 To 10
				Console.WriteLine("Im interesting and Im gonna do something...")

				Console.WriteLine(New Random().Next(2))

				If New Random().Next(2) = 0 Then
					ActionA()
				Else
					ActionB()
				End If

				Console.WriteLine()
			Next
		End Sub
	End Class

	Private Class SomeCuriousClass
		Implements IObserver

		Private name As String

		Public Sub New(ByVal name As String)
			Me.name = name
		End Sub

		Public Sub DoSomething(ByVal _event As String) Implements IObserver.DoSomething
			Console.WriteLine($"observer {name} handled event {_event}")
		End Sub
	End Class

	Sub Main()
		Dim interesting As New SomeInterestingClass

		interesting.AddObserver(New SomeCuriousClass("one"))
		interesting.AddObserver(New SomeCuriousClass("two"))
		interesting.AddObserver(New SomeCuriousClass("three"))

		interesting.Work()

		Console.ReadKey()
	End Sub

End Module
