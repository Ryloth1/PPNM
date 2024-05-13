CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:./$@ $(LIBS) $(CODE)
TIME = time --output $@ --append --format "$$nthreads %e %U" 


Out.txt : main.exe Makefile
	mono $< > $@

matrix.dll : ../../lib/matrix.cs ../../lib/vector.cs ; $(MKLIB)
jacobi.dll : ../../lib/jacobi.cs matrix.dll ; $(MKLIB)


main.exe : main.cs matrix.dll jacobi.dll; $(MKEXE)

clean:
	$(RM) *.exe *.dll [Oo]ut* [Ll]og*
