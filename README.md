# Plumas en guerra 🐥

Juego de combate entre pollitos desarrollado en **Unity 6.3 LTS (6000.3.23f1)**, basado en el tutorial **Tanks** y su escenario de jungla.

## El juego

Elige entre **Pío, Copito, Pepita y Capitán**, dispara huevitos y gana rondas contra la computadora o contra otro jugador en el mismo teclado.

### Personalización y mejoras

- Cuatro personajes con nombres, colores y accesorios propios.
- Animaciones de patitas al caminar y alas al disparar.
- Huevitos como proyectiles y explosión de plumas al morir.
- Sonidos de pasos, píos, carga y disparo.
- Rastro de polvo reutilizado del demo original.
- Semillas: recuperan 40 puntos de vida.
- Cascarón: reduce a la mitad el daño recibido durante 6 segundos.
- Maíz picante: duplica el daño del siguiente disparo.
- Nidos, huevos y sacos de semillas en la jungla.
- Ajustes de puntería, rutas de escape de los bots y detección de impactos.

## Controles

| Acción | Jugador 1 | Jugador 2 |
| --- | --- | --- |
| Avanzar / retroceder | W / S | Flechas arriba / abajo |
| Girar | A / D | Flechas izquierda / derecha |
| Disparar | Espacio | Enter |

Mantén pulsado el botón de disparo para cargar y suéltalo para lanzar. En el menú puedes elegir jugadores o CPU.

## Abrir el proyecto

1. Clona o descarga este repositorio.
2. En Unity Hub, añade la carpeta del proyecto.
3. Ábrelo con **Unity 6000.3.23f1** y espera a que se importen los recursos y paquetes.
4. Abre `Assets/_Tanks/Tutorial_Demo/Demo_Scenes/Demo_Game_Jungle.unity`.
5. Pulsa **Play**.

Para generar una versión de navegador, instala el módulo Web Build Support, selecciona **Web** en Build Profiles y deja habilitada la escena `Demo_Game_Jungle` como escena inicial.

## Organización

- `Assets/PollitosGame`: personajes, efectos, sonidos y scripts de personalización.
- `Assets/_Tanks`: recursos y lógica del tutorial reutilizados.
- `Packages`: dependencias del proyecto.
- `ProjectSettings`: configuración de Unity.

Los builds, grabaciones, copias de seguridad y carpetas temporales de Unity no se incluyen en este repositorio.

## Créditos

Proyecto académico adaptado del tutorial Tanks de Unity. Los recursos de terceros conservan sus licencias originales; este repositorio no les asigna una licencia nueva.
