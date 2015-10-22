﻿// Original Work Copyright (c) Ethan Moffat 2014-2015
// This file is subject to the GPL v2 License
// For additional details, see the LICENSE file

namespace EOLib.Data
{
	internal interface IDataRecordFactory
	{
		IDataRecord CreateRecord(int id);
	}
}
