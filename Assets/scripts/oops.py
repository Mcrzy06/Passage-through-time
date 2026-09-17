class Dog:
    def __init__(self,breed,age,name,colour):
        self.breed = breed
        self.age = age
        self.name = name 
        self.colour = colour

    def run(self):
            print('The '+ self.breed +' is running')

    def sit(self):
            print('The '+ self.breed+' is sitting')

    def get_name(self):
      return self.name
    
    def set_name(self,new_name):
          self.name = new_name


class puppy(Dog):
      def __init__(self,breed,age,name,colour,is_vaccinated=False):
            super().__init__(breed,age,name,colour)
            self.is_vaccinated = is_vaccinated
            
     
      def check_vaccination(self,):
            print(f"Is the puppy vaccinated: {'Yes' if self.is_vaccinated else 'No'}")

            
            
puppy_1 = puppy('alsation',0.6, 'bush', 'brown',True )
dog_1 = Dog('dalamation',3,'bruno','white and black') 
dog_2 = Dog('labrador',5,'Max','black')

dog_2.set_name('charlie')
print(dog_2.get_name())

class node:
      def __init__(self,data):
            self.data = data
            self.next = None

      def get_data(self):
            return self.data
      
      def get_next(self):
            return self.next
      
      def set_next(self,new_next):
            self.next = new_next

class linked_list():
      def __init__(self):
            self.head = None

      def add(self,data):
            new_node = node(data)
            if self.head is None:
                  self.head = new_node
            else:
                  new_node.set_next(self.head)
                  self.head = new_node

My_list = linked_list()

items = (1,6,8,4,3,2,7,9)
def merge_sort(items):
      if len(items) <= 1:
            return items
      else:
            midpoint = (len(items)-1) //2
            left = items[0:midpoint + 1]
            right = items[midpoint +1:len(items)]

            left = merge_sort(left)
            right = merge_sort(right)

            merged_list = merge(left,right)
            return merged_list


def merge(left,right):

 merged = []
 index_left = 0
 index_right = 0

 while index_left < len(left) and index_right < len(right):
       if left[index_left] < right[index_right]:
             merged.append(left[index_left])
             index_left += 1
       else:
            merged.append(right[index_right]) 
            index_right += 1

 while index_left < len(left):
       merged.append(left[index_left])
       index_left += 1

 while index_right < len(right):
       merged.append(right[index_right])
       index_right +=1 
 return merged

print(merge_sort(items))

class node:
      def __init__(self,data):
            self.data = data
            self.next = None

      def get_data(self):
            return self.data
      
      def get_next(self):
            return self.next
      
      def set_next(self,new_next):
            self.next = new_next

class linked_list:
      def __init__(self):
            self.head = None

      def add(self,data):
            new_node = node(data)
            if self.head is None:
                  self.head = new_node
            else:
                  new_node.next(self.head)
                  self.head = new_node