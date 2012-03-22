#!/usr/bin/env python

# This is a prototype of the Music system (in Python).
# This version does not support voices yet but has been stubbed out.

# This version encodes the song Yankee Doodle. It is able to build
# the song measure by measure and print the score. I opted against
# using the "to string" approach in Python and in favor of a 
# getAST() method that gives an "abstract syntax tree" that is
# then formatted using the pprint framework in Python.

# My next stop is C# but I will probably develop a full Python
# version of this at some point! :-)

from fractions import Fraction
import pprint

def chromatic():
   while True:
      yield 1

def major():
   intervals = (2, 2, 1, 2, 2, 2, 1)
   while True:
      for i in intervals:
         yield i


def minor():
   intervals = (2, 1, 2, 2, 1, 2, 2)
   while True:
      for i in intervals:
         yield i

def scale(key, igenerator):
   tone_names = ["C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"]
   tones = range(0, 12)
   nextTone = tone_names.index(key)
  
   while True:
      yield tones[nextTone]
      nextTone = nextTone + igenerator.next() 
      nextTone = nextTone % len(tones)


def render(sgenerator, type):
   if type == 'sharps':
      tones = ["C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"]
   else:
      tones = ["C", "D\'", "D", "E'", "E", "F", "G\'", "G", "A\'", "A", "B\'", "B"]
   while True:
      yield tones[sgenerator.next()]

class Note(object):
   def __init__(self, tone, duration, octave=0):
      self.tone = tone
      self.duration = duration
      self.octave = octave

   def getDuration(self):
      return self.duration

   def getAST(self):
      return [ "Note", self.tone, self.duration, self.octave ]

def Rest(duration):
   return Note(duration, -1, 0)

class Measure(object):
   def __init__(self, score):
      self.score = score
      self.notes = []

   def totalTime(self):
      sum = Fraction(0)
      for n in self.notes:
         sum = sum + n.getDuration()
      return sum

   def isFull(self):
      return self.totalTime() == self.score.time_sig

   def addNote(self, tone, duration, octave):
      if self.totalTime() + duration <= self.score.time_sig:
         self.notes.append(Note(tone, duration, octave))
         return True
      else:
         return False

   def getAST(self):
      return [ "Measure", "TotalTime %s" % self.totalTime(), [ n.getAST() for n in self.notes ] ]


class Score(object):
   def __init__(self, key_sig, time_sig, num_measures):
      self.key_sig = [ key_sig.next() for i in range(0, 8) ]
      self.time_sig = Fraction(time_sig)
      self.measures = []
      for i in range(0, num_measures):
         self.measures.append(Measure(self))
      self.voices = {}

   # must register all voices before creating music
   def addVoice(self, name):
      self.voices[name] = name;

   def measure(self, number):
      return self.measures[number]
   
   def getAST(self):
      return ["Score", self.key_sig, self.time_sig,
               [ m.getAST() for m in self.measures ] ]


# This is the main "method" for now...
# We are encoding Yankee Doodle, a song in C major, 4/4 time.

c_major = scale("C", major())
s = Score(c_major, "4/4", 8)
s.addVoice("Piano")

# Because there are a bunch of note objects to create, I went ahead
# and set up a shorthand. Just using note, duration (as an integer), and
# octave for now. If the duration and octave are missing, we'll assume 1:0
# are present (e.g. C = C:1:0 = C 1/4 0 (for middle C)

yankee_doodle = \
"C C D E C E D:2 C C D E C:2 B:2:-1 C C D E F E D C B:1:-1 G:1:-1 A:1:-1 B:1:-1 C:2 C:2"

yankee_tokens = yankee_doodle.split()

measure_number = 0
for note_token in yankee_tokens:
   while s.measure(measure_number).isFull():
      measure_number = measure_number + 1
   tokens = note_token.split(":")
   if len(tokens) == 3:
      (tone_name, duration, octave) = tokens
   elif len(tokens) == 2:
      (tone_name, duration, octave) = tokens + ["0"]
   else:
      (tone_name, duration, octave) = tokens + ["1", "0"]

   duration_fraction = Fraction(duration + "/4")
   print "Adding %s %s %s to measure %s" % (tone_name, duration_fraction, octave, measure_number)
   s.measure(measure_number).addNote(tone_name, duration_fraction, int(octave)) 

print "Musical Score"

pp = pprint.PrettyPrinter()

pp.pprint( s.getAST() )
