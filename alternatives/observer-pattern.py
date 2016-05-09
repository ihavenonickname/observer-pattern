class Signal:
	def __init__(self):
		self.callbacks = []
	
	def connect(self, callback):
		self.callbacks.append(callback)
	
	def fire(self, *args):
		for callback in self.callbacks:
			callback(*args)

class BookStore:
	def __init__(self):
		self.book_sold = Signal()
		
		self.books = [
			"The God Delusion - Dawkins",
			"Animal Farm - Orwell",
			"Symposium - Plato",
			"Ecce Homo - Nietzsche",
			"The Trial - Kafka"
		]
		
	def sell(self, bookname):
		try:
			self.books.remove(bookname)
			self.book_sold.fire(bookname, self.books)
		except ValueError:
			pass

def logger(booksold, books):
	print("%s sold, there are more %d books" % (booksold, len(books)))

bs = BookStore()
bs.book_sold.connect(logger)
bs.sell("The God Delusion - Dawkins")
bs.sell("Muito Mais Que 5inco Minutos – Kefera")
bs.sell("Ecce Homo - Nietzsche")
