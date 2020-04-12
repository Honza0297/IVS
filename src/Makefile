all: run

pack:
	if exist ..\..\xbuben05_xberan43_xdragu01 rmdir /s /q ..\..\xbuben05_xberan43_xdragu01
	if exist ..\..\xbuben05_xberan43_xdragu01.zip del ..\..\xbuben05_xberan43_xdragu01.zip
	mkdir ..\..\xbuben05_xberan43_xdragu01
	mkdir ..\..\xbuben05_xberan43_xdragu01\doc
	mkdir ..\..\xbuben05_xberan43_xdragu01\repo
	mkdir ..\..\xbuben05_xberan43_xdragu01\install
	xcopy /e /h ..\doc ..\..\xbuben05_xberan43_xdragu01\doc
	xcopy /e /h IVSCalc\install ..\..\xbuben05_xberan43_xdragu01\install
	xcopy /e /h ..\..\IVS ..\..\xbuben05_xberan43_xdragu01\repo
	powershell Compress-Archive ..\..\xbuben05_xberan43_xdragu01 ..\..\xbuben05_xberan43_xdragu01.zip

clean:
	git clean -d -f -x

run: 
	.\IVSCalc\bin\Release\IVSCalc.exe

profile:
	.\stddev\bin\Release\stddev.exe <.\stddev\data.txt

install:
	.\IVSCalc\install\setup.exe


help:
	@echo EN version:
	@echo Use command "make" or "make run" for running IVSCalc. Use "make install" for installing IVSCalc.
	@echo CZ verze:
	@echo Pouzijte prikaz "make" nebo "make run" pro spusteni IVSCalc. Pro instalaci programu pouzijte "make install".