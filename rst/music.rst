.. todo::
   This is completely in draft mode now and is at best in placeholder status.
   No revisions please.

Array Example: Music
===========================

We begin from the twelve-tone system.

.. literalinclude:: ../projects/Music/Scales/Main.cs
   :start-after: chunk-tones-begin
   :end-before: chunk-tones-end
   :linenos:


This computes the scale using the supplied steps array.
The steps array can be any scale you like, including one not used in music but we are going to use it
to get major and minor scales.

.. literalinclude:: ../projects/Music/Scales/Main.cs
   :start-after: chunk-compute-begin
   :end-before: chunk-compute-end
   :linenos:

This writes a computed scale to the console.

.. literalinclude:: ../projects/Music/Scales/Main.cs
   :start-after: chunk-write-begin
   :end-before: chunk-write-end
   :linenos:

This puts it all together...

.. literalinclude:: ../projects/Music/Scales/Main.cs
   :start-after: chunk-main-begin
   :end-before: chunk-main-end
   :linenos:


