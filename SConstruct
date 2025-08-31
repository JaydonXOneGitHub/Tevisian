from SCons.Script import Environment, Glob
import os

env: Environment = Environment()

WIN: str = "nt"
LINUX: str = "posix"

include_dirs: list[str] = [
    "code/include",
    "thirdparty/include"
]

lib_paths: list[str] = [
    "thirdparty/lib/sfml"
]

win_libs: list[str] = [
    "FLAC",
    "freetype",
    "ogg",
    "sfml-audio",
    "sfml-graphics",
    "sfml-network",
    "sfml-system",
    "sfml-window",
    "vorbis",
    "vorbisenc",
    "vorbisfile"
]

linux_libs: list[str] = [
    "sfml-audio",
    "sfml-graphics",
    "sfml-network",
    "sfml-system",
    "sfml-window"
]

compiler_flags: list[str] = []

linker_flags: list[str] = []

defines: list[str] = []

env.Append(CPPPATH=include_dirs)
env.Append(LIBPATH=lib_paths)
env.Append(LINKFLAGS=linker_flags)

if os.name == WIN:
    compiler_flags.append('/std:c++17')
    env.Append(LIBS=win_libs)

elif os.name == LINUX:
    compiler_flags.append('-std=c++17')
    linker_flags.append(
        '-Wl,'
        '-rpath,'
        '$ORIGIN/thirdparty/lib/sfml,'
    )
    env.Append(LIBS=linux_libs)
    defines.append("LINUX")

env.Append(CPPDEFINES=defines)
env.Append(CXXFLAGS=compiler_flags)

sources = Glob("code/src/core/*.cpp")
sources += Glob("code/src/plugin/*.cpp")

sources.append("code/main.cpp")

target: str = "build/Tevisian"

env.Program(target=target, source=sources)