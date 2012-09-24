import re
from enchant.tokenize import Filter

class AcronymFilter(Filter):
    """If a word looks like an acronym (all upper case letters),
    ignore it.
    """

    def _skip(self, word):
        return (word == word.upper() # all caps
                or
                # pluralized acronym ("URLs")
                (word[-1].lower() == 's'
                 and
                 word[:-1] == word[:-1].upper()
                 )
                )

class JavaCaseFilter(Filter):
   """Ignore CamelCase where the first letter is lowercase
   Allow final digits"""

   # p2 = r"^([A-Za-z]\w+[A-Z]+\w+)"
   _pattern = re.compile(r'[a-z]+[A-Z]([a-z]*[A-Z])*[a-z]+[1-9]*')

   def _skip(self, word):
       return bool(self._pattern.match(word))

class UnderscoreFilter(Filter):
   """underscore sep
   Allow final digits with no _ before"""

   _pattern = re.compile(r'[a-z]+_([a-z]+_)*[a-z]+[1-9]*')

   def _skip(self, word):
       return bool(self._pattern.match(word))

      
