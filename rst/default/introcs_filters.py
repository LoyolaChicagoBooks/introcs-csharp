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
   """Ignore CamelCase where the first letter is lowercase"""

   _pattern = re.compile(r"^([A-Za-z]\w+[A-Z]+\w+)")

   def _skip(self, word):
       if self._pattern.match(word):
          return True
       return False

      
