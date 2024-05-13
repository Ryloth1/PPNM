CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

default : Out1.gnuplot.svg Out2.gnuplot.svg Out3.gnuplot.svg

Out1.gnuplot.svg : Out1.txt Makefile
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

Out2.gnuplot.svg : Out2.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set key left ;\
		set xlabel "x" ;\
		set ylabel "gamma(x)" ;\
		set tics out ;\
		set grid ;\
		set title "Gamma function" ;\
		set yrange [-25:25] ;\
		plot [-5:5]\
			"$<" with lines notitle\
			,"factorial.data.txt" using 1:2 with points pointtype 6 notitle\
	' | tee log.gpi | gnuplot

Out3.gnuplot.svg : Out3.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set key left ;\
		set xlabel "x" ;\
		set ylabel "lngamm(x)" ;\
		set tics out ;\
		set grid ;\
		set title "lnGamma function" ;\
		plot [-3:10]\
			"$<" with lines notitle\
			,"lnfactorial.data.txt" using 1:2 with points pointtype 6 notitle\
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

