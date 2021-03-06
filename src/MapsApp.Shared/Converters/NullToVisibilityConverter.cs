﻿// /*******************************************************************************
//  * Copyright 2018 Esri
//  *
//  *  Licensed under the Apache License, Version 2.0 (the "License");
//  *  you may not use this file except in compliance with the License.
//  *  You may obtain a copy of the License at
//  *
//  *  http://www.apache.org/licenses/LICENSE-2.0
//  *
//  *   Unless required by applicable law or agreed to in writing, software
//  *   distributed under the License is distributed on an "AS IS" BASIS,
//  *   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  *   See the License for the specific language governing permissions and
//  *   limitations under the License.
//  ******************************************************************************/
using System;
using System.Globalization;
#if __ANDROID__ || __IOS__ || NETFX_CORE
using IValueConverter = Xamarin.Forms.IValueConverter;
#else
using System.Windows.Data;
using System.Windows;
#endif

namespace Esri.ArcGISRuntime.OpenSourceApps.MapsApp.Converters
{ /// <summary>
  /// Converts null to control visibility
  /// </summary>
    class NullToVisibilityConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Handle null to visibility and not null (inverse) to visibility
            if (parameter != null && parameter.ToString() == "Inverse")
            {
                //if value is null, control is visible
#if __ANDROID__ || __IOS__ || NETFX_CORE
            return (value == null) ? true : false;
#else
                return (value == null) ? Visibility.Visible : Visibility.Collapsed;
#endif
            }
            else
            {
                //if value is null, control is not visible
#if __ANDROID__ || __IOS__ || NETFX_CORE
            return (value == null) ? false : true;
#else
                return (value == null) ? Visibility.Collapsed : Visibility.Visible;
#endif
            }
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
