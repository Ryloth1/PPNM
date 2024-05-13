CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:./$@ $(LIBS) $(CODE)
TIME = time --output $@ --append --format "$$nthreads %e %U" 

default : OutA.txt OutB.txt OutC.txt

OutA.gnuplot.svg : OutA.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set key left ;\
		set xlabel "x" ;\
		set ylabel "sin(x)" ;\
		set tics out ;\
		set grid ;\
		set title "Lin interpol of Sin" ;\
		plot [-1:10]\
			"$<" with lines notitle\
			,"erf.data.txt" using 1:2 with points pointtype 6 notitle\
			,"erf.data.txt" using (-($$1)):(-($$2)) with points pointtype 6 notitle\
	' | tee log.gpi | gnuplot

OutA.txt : mainA.exe Makefile
	mono $< > $@
OutB.txt : mainB.exe Makefile
	mono $< > $@
OutC.txt : mainC.exe Makefile
	mono $< > $@



matrix.dll : ../../lib/matrix.cs ../../lib/vector.cs ; $(MKLIB)
qrgs.dll : ../../lib/qrgs.cs matrix.dll ; $(MKLIB)
ls.dll : ../../lib/ls.cs qrgs.dll matrix.dll ; $(MKLIB)

mainA.exe : mainA.cs matrix.dll qrgs.dll ls.dll; $(MKEXE)

clean:
	$(RM) *.exe *.dll [Oo]ut* [Ll]og*
