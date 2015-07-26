Musical Scales and Arrays
===========================

Music in the western classical tradition uses a twelve-tone *chromatic* 
scale. Any of the tones in this scale can be the basis of a major scale.
Most musicians (especially pianists) learn the C-major scale in the early
days of study, owing to the ability to play this scale entirely with the
ivory (white) keys.

The following declaration shows how to initialize an array consisting
of the twelve tones of the chromatic scale, starting from the C note.

.. literalinclude:: ../../source/examples/music_nunit/scales.cs
   :start-after: chunk-tones-begin
   :end-before: chunk-tones-end
   :linenos:

Even if you're not a musician, learning the basic principles is fairly
straightforward.

The well-known C-major scale, which is often sung as::

   Do Re Mi Fa So La Ti Do

has the following progression::

   C  D  E  F  G  A  B  C

This progression is known as the *diatonic major* scale. If you look at
the ``tones`` array, you can actually figure out the intervals associated
with this array::

   C + 2 = D
   D + 2 = E
   E + 1 = F
   F + 2 = G
   G + 2 = A
   A + 2 = B
   B + 1 = C

So given any starting note, the major scale can be *generated* from the
intervals (represented as an array).

So, for example, if you want the F-major scale, you can get it by starting
at F and applying the steps of 2, 2, 1, 2, 2, 2, 1::

   F + 2 = G
   G + 2 = A
   A + 1 = B' (flat) a.k.a. A#)
   B'+ 2 = C
   C + 2 = D
   D + 2 = E
   E + 1 = F

So this is the F-major scale::

   F G A B' C D E F



We begin by creating a helper function, ``FindTone()``, which does a 
linear search to find the key of the scale we want to compute. The 
aim is to make it easy for the user to just specify the key of interest.
Then we can use this position to compute the scale given the major
(or minor, covered shortly) interval array.


.. literalinclude:: ../../source/examples/music_nunit/scales.cs
   :start-after: chunk-findtone-begin
   :end-before: chunk-findtone-end
   :linenos:

To see what this function does, pick your favorite key (C and G are very
common for beginners). 

- ``FindTone("C")`` gives 0, the first position in the ``tones`` array.
- ``FindTone("G")`` gives 8.


For example,
C is the first note in the array of tones, so ``FindTone("C")`` would give
us 0. ``FindTone("F")`` would give us 6.

So let's take a look at ``ComputeScale()`` which does the work of
computing a scale, given a key and an array of steps. The scale array
is allocated by the ``Main()`` method, primarily to allow the same
array to be used repeatedly for calculating other scales.

.. literalinclude:: ../../source/examples/music_nunit/scales.cs
   :start-after: chunk-compute-begin
   :end-before: chunk-compute-end
   :linenos:

#. The first thing to note is the *setup* of this code. We're going to
   keep the ``startTone`` (obtained by calling ``FindTone()``) and 
   ``tonePosition``, which is the note we are presently visiting in
   the ``tones`` array. 

#. Remember that every scale (e.g. C, D, F#, etc.) can always be
   obtained by looking at ``tones`` and using the appropriate 
   intervals (the ``steps`` parameter) to compute the next note, given
   a current note. 

#. We do some simple checks in line 6 (to ensure that a valid key
   was specified by the caller) and in line 8 to ensure that the 
   number of steps + 1 is the length of the scale--and the length
   of the scale is 8. (We technically don't have to limit the scale
   to 8, because scales can keep going until you run out of playable
   notes on the instrument.)
   
   .. later?
       , but we're going to expand this example
       when we cover object-oriented programming. So stay *tuned*...pun
       intended.)

#. We'll now start at the initial position (where we found the base
   note of the key) and enter a for loop to compute all of the notes
   in the scale. This loop iterates over the entries in the ``steps``
   array to decide what the next note is.

#. The next note in the scale, ``scale[i]`` is computed by taking
   ``tonePosition % tones.GetLength(0)``. We need to do this, because
   in most scales, you will eventually end up "falling off the end"
   of the ``tones`` array, which mens that you need to continue
   computing notes from the *beginning* of the array. You can inspect
   this for yourself by picking a scale (say, B) that is starting at
   the end of the ``tones`` array. This means you will need to go
   to the beginning of the array to get C# (which is 2 tones away
   from B). 

#. The next note is found by adding ``steps[i]`` to ``tonePosition``.


The following function writes the scale out (rather naively) by just
printing the notes from our existing ``tones`` array.

.. literalinclude:: ../../source/examples/music_nunit/scales.cs
   :start-after: chunk-write-begin
   :end-before: chunk-write-end
   :linenos:

We say that the output is *naive* because any musician will tell you
that a scale should be printed in a normalized way. For example, the F-major
scale (shown above in our earlier explanation) is never written with A# as
one of its notes. It is written as B-flat. It's easy to manage the various
cases by consulting the circle of fifths, which gives us guidance on the
number of flats/sharps each scale has. 

.. later?
    We'll revisit this topic again later
    during our discussion of the OOP version.

Lastly, we put this all together.

.. literalinclude:: ../../source/examples/music_nunit/scales.cs
   :start-after: chunk-main-begin
   :end-before: chunk-main-end
   :linenos:

This ``Main()`` method shows how to set up the steps for both major
and minor scales. We've already explained how to express the steps of
a major scale. The minor scale basically drops the 3rd and 7th by a
semitone (a single step), which gives us a different pattern. 

You can run this program to see the major and minor scales. 

.. later?

    We plan on
    doing a bit more with this example later when we have the power of
    classes and objects, which can be greatly helpful for organizing the
    other major ideas of music besides scales. For example, we may wish
    to express a song using tablature and perform a transposition to a different
    scale. For this and many other more advanced ideas, having classes and
    objects is a must.
