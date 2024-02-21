CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
TIME = time --output $@ --append --format "$$nthreads %e %U" 

default : Out.times.svg out2.times.txt out3.times.txt

Out.times.svg : out1.times.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set xlabel "number of threads";\
		set ylabel "real time ";\
		set title "Running time as function of number of threads";\
		plot "$<" using 2:3 with lp;\
		' |tee log.gpi | gnuplot




N=2e8
out1.times.txt : main1.exe Makefile
	>$@
	$(TIME) mono $< -nterms:$N -nthreads:1 >>$@
	$(TIME) mono $< -nterms:$N -nthreads:2 >>$@
	$(TIME) mono $< -nterms:$N -nthreads:3 >>$@
	$(TIME) mono $< -nterms:$N -nthreads:4 >>$@
	$(TIME) mono $< -nterms:$N -nthreads:5 >>$@
	$(TIME) mono $< -nterms:$N -nthreads:6 >>$@
	$(TIME) mono $< -nterms:$N -nthreads:7 >>$@
	$(TIME) mono $< -nterms:$N -nthreads:8 >>$@

out2.times.txt : main2.exe Makefile
	>$@
	$(TIME) mono $< -nterms:$N >>$@


out3.times.txt : main3.exe Makefile
	>$@
	$(TIME) mono $< -nterms:$N >>$@

main1.exe : main1.cs ; $(MKEXE)
main2.exe : main2.cs ; $(MKEXE)
main3.exe : main3.cs ; $(MKEXE)

clean:
	$(RM) *.exe *.dll [Oo]ut* [Ll]og*
