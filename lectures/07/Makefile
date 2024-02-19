CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

Out1.erf.gnuplot.svg : Out1.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set key left ;\
		set xlabel "x" ;\
		set ylabel "erf(x)" ;\
		set tics out ;\
		set grid ;\
		set title "Error function" ;\
		plot [-3:3]\
			"$<" with lines notitle\
			,"erf.data.txt" using 1:2 with points pointtype 6 notitle\
			,"erf.data.txt" using (-($$1)):(-($$2)) with points pointtype 6 notitle\
	' | tee log.gpi | gnuplot

Out2.erf.gnuplot.svg : Out2.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set key left ;\
		set xlabel "x" ;\
		set ylabel "erf(x)" ;\
		set tics out ;\
		set grid ;\
		set title "Error function" ;\
	' | tee log.gpi | gnuplot

Out3.erf.gnuplot.svg : Out3.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set key left ;\
		set xlabel "x" ;\
		set ylabel "erf(x)" ;\
		set tics out ;\
		set grid ;\
		set title "Error function" ;\
	' | tee log.gpi | gnuplot

Out1.txt : main1.exe Makefile
	mono $< > $@

Out2.txt : main2.exe Makefile
	mono $< > $@

Out3.txt : main3.exe Makefile
	mono $< > $@

sfuns.dll : sfuns.cs ; $(MKLIB)
main1.exe : main1.cs sfuns.dll; $(MKEXE)
main2.exe : main2.cs sfuns.dll; $(MKEXE)
main3.exe : main3.cs sfuns.dll; $(MKEXE)

clean:
	$(RM) *.exe *.dll [Oo]ut* [Ll]og*

