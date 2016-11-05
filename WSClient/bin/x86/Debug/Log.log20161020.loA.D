2016-10-20 14:06:38,254 [1] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 14:06:39,767 [1] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 14:06:44,155 [1] INFO  WSClient.Program - getServicios 
2016-10-20 14:06:50,434 [1] INFO  WSClient.Program - getServicios 
2016-10-20 14:07:09,057 [1] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 14:07:10,596 [1] DEBUG WSClient.Program - setServicio : Procesando llamados
2016-10-20 14:07:15,050 [1] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 14:07:21,811 [1] INFO  WSClient.Program - getServicios 
2016-10-20 14:07:29,862 [1] INFO  WSClient.Program - getServicios 
2016-10-20 14:07:45,085 [1] INFO  WSClient.Program - Geocodificacion : address=981     +ARIEL, CAMINO                   +%26+WATERLOO, CAMINO                        ,+,+Montevideo
2016-10-20 14:07:45,897 [1] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 14:07:47,370 [1] DEBUG WSClient.Program - setServicio : Procesando llamados
2016-10-20 14:07:52,186 [1] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 14:08:00,666 [1] INFO  WSClient.Program - getServicios 
2016-10-20 14:08:09,295 [1] INFO  WSClient.Program - getServicios 
2016-10-20 14:08:23,368 [1] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 14:08:24,564 [1] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 14:08:27,542 [1] INFO  WSClient.Program - getServicios 
2016-10-20 14:08:34,370 [1] INFO  WSClient.Program - getServicios 
2016-10-20 14:08:50,868 [1] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 14:08:52,517 [1] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 14:08:55,711 [1] INFO  WSClient.Program - getServicios 
2016-10-20 14:09:01,460 [1] INFO  WSClient.Program - getServicios 
2016-10-20 14:09:14,930 [1] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 14:09:16,319 [1] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 14:09:19,593 [1] INFO  WSClient.Program - getServicios 
2016-10-20 14:09:27,180 [1] INFO  WSClient.Program - getServicios 
2016-10-20 14:09:48,360 [1] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 14:09:50,222 [1] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 14:09:55,470 [1] INFO  WSClient.Program - getServicios 
2016-10-20 14:10:02,219 [1] INFO  WSClient.Program - getServicios 
2016-10-20 14:10:19,400 [1] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 14:10:20,916 [1] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 14:10:25,490 [1] INFO  WSClient.Program - getServicios 
2016-10-20 14:10:33,943 [1] INFO  WSClient.Program - getServicios 
2016-10-20 14:10:54,655 [1] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 14:10:56,014 [1] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 14:10:59,151 [1] INFO  WSClient.Program - getServicios 
2016-10-20 14:11:06,582 [1] INFO  WSClient.Program - getServicios 
2016-10-20 14:11:23,774 [1] ERROR WSClient.Program - Error al cerrar servicio llamados System.ArgumentOutOfRangeException: Index was out of range. Must be non-negative and less than the size of the collection.
Parameter name: index
   at System.ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument argument, ExceptionResource resource)
   at System.Collections.Generic.List`1.get_Item(Int32 index)
   at Newtonsoft.Json.Linq.JContainer.GetItem(Int32 index)
   at Newtonsoft.Json.Linq.JArray.get_Item(Object key)
   at WSClient.models.Llamados.updateLlamadosR(List`1 rowList, JObject servicio) in C:\GITRepositorio\com.ws.russomando\WSClient\data\Llamados.cs:line 150
   at WSClient.models.Llamados.finalizarServicio(JArray serviciosFinalizados) in C:\GITRepositorio\com.ws.russomando\WSClient\data\Llamados.cs:line 89
   at WSClient.services.ServicesController.cerrarServicio(Servicio servicio, String estado) in C:\GITRepositorio\com.ws.russomando\WSClient\services\ServicesController.cs:line 220
2016-10-20 14:11:25,963 [1] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 14:11:28,053 [1] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 14:11:33,020 [1] INFO  WSClient.Program - getServicios 
2016-10-20 14:11:40,707 [1] INFO  WSClient.Program - getServicios 
2016-10-20 14:11:56,861 [1] ERROR WSClient.Program - Error al cerrar servicio llamados System.ArgumentOutOfRangeException: Index was out of range. Must be non-negative and less than the size of the collection.
Parameter name: index
   at System.ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument argument, ExceptionResource resource)
   at System.Collections.Generic.List`1.get_Item(Int32 index)
   at Newtonsoft.Json.Linq.JContainer.GetItem(Int32 index)
   at Newtonsoft.Json.Linq.JArray.get_Item(Object key)
   at WSClient.models.Llamados.updateLlamadosR(List`1 rowList, JObject servicio) in C:\GITRepositorio\com.ws.russomando\WSClient\data\Llamados.cs:line 150
   at WSClient.models.Llamados.finalizarServicio(JArray serviciosFinalizados) in C:\GITRepositorio\com.ws.russomando\WSClient\data\Llamados.cs:line 89
   at WSClient.services.ServicesController.cerrarServicio(Servicio servicio, String estado) in C:\GITRepositorio\com.ws.russomando\WSClient\services\ServicesController.cs:line 220
2016-10-20 14:11:58,678 [1] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 14:12:00,583 [1] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 14:12:06,337 [1] INFO  WSClient.Program - getServicios 
2016-10-20 14:12:13,965 [1] INFO  WSClient.Program - getServicios 
2016-10-20 14:12:30,918 [1] ERROR WSClient.Program - Error al cerrar servicio llamados System.ArgumentOutOfRangeException: Index was out of range. Must be non-negative and less than the size of the collection.
Parameter name: index
   at System.ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument argument, ExceptionResource resource)
   at System.Collections.Generic.List`1.get_Item(Int32 index)
   at Newtonsoft.Json.Linq.JContainer.GetItem(Int32 index)
   at Newtonsoft.Json.Linq.JArray.get_Item(Object key)
   at WSClient.models.Llamados.updateLlamadosR(List`1 rowList, JObject servicio) in C:\GITRepositorio\com.ws.russomando\WSClient\data\Llamados.cs:line 150
   at WSClient.models.Llamados.finalizarServicio(JArray serviciosFinalizados) in C:\GITRepositorio\com.ws.russomando\WSClient\data\Llamados.cs:line 89
   at WSClient.services.ServicesController.cerrarServicio(Servicio servicio, String estado) in C:\GITRepositorio\com.ws.russomando\WSClient\services\ServicesController.cs:line 220
2016-10-20 18:51:57,701 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 18:52:04,360 [10] DEBUG WSClient.Program - setServicio : Procesando llamados
2016-10-20 18:52:14,331 [10] DEBUG WSClient.Program - setServicio : Procesando llamados
2016-10-20 18:52:20,492 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 18:52:38,344 [10] INFO  WSClient.Program - getServicios 
2016-10-20 18:52:50,988 [10] INFO  WSClient.Program - getServicios 
2016-10-20 18:53:16,423 [10] INFO  WSClient.Program - Geocodificacion : address=1268    +SERVIDUMBRE                     +%26+PJE F                                   ,+,+Montevideo
2016-10-20 18:53:17,498 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 18:53:19,635 [10] DEBUG WSClient.Program - setServicio : Procesando llamados
2016-10-20 18:53:25,179 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 18:53:33,823 [10] INFO  WSClient.Program - getServicios 
2016-10-20 18:53:46,177 [10] INFO  WSClient.Program - getServicios 
2016-10-20 18:54:12,146 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 18:54:14,666 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 18:54:25,109 [10] INFO  WSClient.Program - getServicios 
2016-10-20 18:54:37,589 [10] INFO  WSClient.Program - getServicios 
2016-10-20 18:55:01,993 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 18:55:03,973 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 18:55:13,170 [10] INFO  WSClient.Program - getServicios 
2016-10-20 18:55:22,297 [10] INFO  WSClient.Program - getServicios 
2016-10-20 18:55:42,325 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 18:55:43,930 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 18:55:49,214 [10] INFO  WSClient.Program - getServicios 
2016-10-20 18:55:56,789 [10] INFO  WSClient.Program - getServicios 
2016-10-20 18:56:09,175 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 18:56:10,356 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 18:56:15,049 [10] INFO  WSClient.Program - getServicios 
2016-10-20 18:56:21,263 [10] INFO  WSClient.Program - getServicios 
2016-10-20 18:56:35,589 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 18:56:36,894 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 18:56:42,871 [10] INFO  WSClient.Program - getServicios 
2016-10-20 18:56:50,251 [10] INFO  WSClient.Program - getServicios 
2016-10-20 18:57:09,212 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 18:57:11,355 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 18:57:19,459 [10] INFO  WSClient.Program - getServicios 
2016-10-20 18:57:31,457 [10] INFO  WSClient.Program - getServicios 
2016-10-20 18:57:56,150 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 18:57:59,080 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 18:58:07,316 [10] INFO  WSClient.Program - getServicios 
2016-10-20 18:58:17,004 [10] INFO  WSClient.Program - getServicios 
2016-10-20 18:58:35,232 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 18:58:36,633 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 18:58:40,157 [10] INFO  WSClient.Program - getServicios 
2016-10-20 18:58:46,768 [10] INFO  WSClient.Program - getServicios 
2016-10-20 18:58:59,419 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 18:59:00,595 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 18:59:04,023 [10] INFO  WSClient.Program - getServicios 
2016-10-20 18:59:08,902 [10] INFO  WSClient.Program - getServicios 
2016-10-20 18:59:22,126 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 18:59:23,600 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 18:59:27,143 [10] INFO  WSClient.Program - getServicios 
2016-10-20 18:59:32,529 [10] INFO  WSClient.Program - getServicios 
2016-10-20 18:59:49,581 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 18:59:51,548 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 18:59:56,811 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:00:04,662 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:00:27,090 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:00:29,432 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:00:35,493 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:00:45,176 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:01:07,721 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:01:09,685 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:01:14,950 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:01:22,603 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:01:39,273 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:01:40,494 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:01:43,559 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:01:48,446 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:01:59,860 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:02:00,832 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:02:03,511 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:02:09,824 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:02:49,600 [10] INFO  WSClient.Program - Geocodificacion : address=        +CAMINO GUERRA                   +%26+VARSOVIA PJ B S14                       ,+,+Montevideo
2016-10-20 19:02:55,550 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:03:03,386 [10] DEBUG WSClient.Program - setServicio : Procesando llamados
2016-10-20 19:03:14,448 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:04:05,204 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:04:16,377 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:04:48,378 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:04:53,408 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:05:01,231 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:05:10,461 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:05:38,238 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:05:41,044 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:06:02,305 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:06:27,208 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:07:06,805 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:07:09,303 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:07:15,744 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:07:27,437 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:07:57,475 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:08:00,740 [10] DEBUG WSClient.Program - setServicio : Procesando llamados
2016-10-20 19:08:06,773 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:08:18,165 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:08:27,419 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:09:21,390 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:09:23,696 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:09:29,052 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:09:38,166 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:10:13,441 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:10:15,762 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:10:23,435 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:10:37,625 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:11:05,795 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:11:07,041 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:11:13,245 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:11:24,067 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:11:57,636 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:12:00,802 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:12:12,117 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:12:23,537 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:12:45,638 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:12:48,456 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:12:55,016 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:13:03,956 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:13:19,860 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:13:21,438 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:13:27,668 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:13:36,611 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:13:56,518 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:13:59,040 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:14:09,003 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:14:17,138 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:14:37,108 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:14:38,338 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:14:43,748 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:14:51,440 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:15:10,216 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:15:11,962 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:15:18,180 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:15:26,067 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:15:40,531 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:15:41,946 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:15:48,701 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:15:57,689 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:16:12,921 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:16:14,307 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:16:21,478 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:16:29,821 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:16:47,756 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:16:49,327 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:16:56,339 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:17:04,397 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:17:19,234 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:17:20,527 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:17:27,026 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:17:35,748 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:17:56,219 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:17:57,629 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:18:04,613 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:18:11,640 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:18:35,700 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:18:38,329 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:18:45,645 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:18:57,920 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:19:15,589 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:19:17,239 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:19:23,327 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:19:30,899 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:19:49,810 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:19:51,272 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:19:57,350 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:20:07,418 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:20:36,715 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:20:38,490 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:20:45,466 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:20:55,560 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:21:11,077 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:21:13,008 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:21:19,349 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:21:26,083 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:21:45,909 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:21:47,449 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:21:54,565 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:22:06,405 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:22:31,980 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:22:33,728 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:22:41,448 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:22:50,893 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:23:06,018 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:23:07,269 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:23:12,589 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:23:18,847 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:23:33,555 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:23:34,784 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:23:40,757 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:23:50,267 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:24:09,912 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:24:11,843 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:24:20,237 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:24:31,521 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:24:51,965 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:24:53,601 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:25:00,597 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:25:09,495 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:25:25,674 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:25:26,834 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:25:32,176 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:25:38,570 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:25:51,575 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:25:53,267 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:25:58,289 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:26:05,959 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:26:29,305 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:26:31,102 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:26:38,576 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:26:49,300 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:27:12,135 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:27:14,594 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:27:22,267 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:27:31,814 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:27:47,741 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:27:49,147 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:27:54,220 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:28:01,435 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:28:12,895 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:28:13,887 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:28:18,417 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:28:24,720 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:28:39,191 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:28:40,693 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:28:47,355 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:28:56,540 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:29:16,538 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:29:18,600 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:29:28,788 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:29:43,578 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:30:03,961 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:30:06,033 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:30:14,017 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:30:23,054 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:30:37,387 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:30:38,630 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:30:43,965 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:30:49,907 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:31:00,039 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:31:01,012 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:31:05,252 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:31:12,898 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:31:26,850 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:31:28,149 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:31:33,824 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:31:42,654 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:32:01,992 [10] DEBUG WSClient.Program - altaServicio : Procesando llamados
2016-10-20 19:32:03,891 [10] DEBUG WSClient.Program - listarServicio : Procesando llamados
2016-10-20 19:32:13,547 [10] INFO  WSClient.Program - getServicios 
2016-10-20 19:32:29,350 [10] INFO  WSClient.Program - getServicios 
